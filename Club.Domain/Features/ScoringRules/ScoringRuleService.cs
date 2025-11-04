namespace Club.Domain.Features.ScoringRules;

public interface IScoringRuleService
{
    [Telemetry]
    Task<ScoringAnalysisResponse?> ScoringAnalysis(ScoringAnalysisRequest request, CancellationToken cancellationToken);
}

public record ScoringAnalysisRequest(TriggerType TriggerType, Customer Customer, long EventLogId, 
    Dictionary<string, string>? Parameters)
{
    public int? EventChannelId { get; set; }
    public int? EventTypeId { get; set; }
    public int? PromotionId { get; set; }
    public int? PointLevelId { get; set; }
    [OldDbMap("ProductId")]
    public int? AwardId { get; set; }
    public int? TenantProductOrServiceId { get; set; }

    public List<PointLevel>? CustomerPointLevels { get; set; }
}

public record ScoringAnalysisResponse
{
    public int ActionCount { get; set; }
}

internal class ScoringRuleService(
    IScoringRuleActionService scoringRuleActionService,
    IEvaluateFormulaService evaluateFormulaService,
    ICustomerService customerService,
    IQueryRepository<ScoringRuleTriggerCondition, int> scoringRuleConditionRepo,
    IQueryRepository<ScoringRuleAction, int> scoringRuleActionRepo,
    ILogger<ScoringRuleService> logger
    ) : IScoringRuleService
{
    public async Task<ScoringAnalysisResponse?> ScoringAnalysis(ScoringAnalysisRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<int> scoringRules = await scoringRuleConditionRepo.GetEntityAsQueryable()
            .Where(x =>
            x.TriggerType==TriggerType.Event ?
                x.EventTypeId == request.EventTypeId &&
                (x.EventChannelId == null || x.EventChannelId.Value == request.EventChannelId):
            x.TriggerType == TriggerType.Promotion?
                x.PromotionId == request.PromotionId :
            x.TriggerType == TriggerType.UpgradePointLevel ?
                x.PointLevelId == request.PointLevelId :
            (x.TriggerType == TriggerType.PurchaseAward || x.TriggerType == TriggerType.ConsumeAward) ?
                x.AwardId == request.AwardId :
            x.TriggerType == TriggerType.PurchaseProductOrService ?
                x.TenantProductOrServiceId == request.TenantProductOrServiceId : false
            )
            .Select(x => x.ScoringRuleId)
            .Distinct().ToListAsync(cancellationToken);
        Dictionary<int, List<ScoringRuleTriggerCondition>> scoringRulesConditions = (await scoringRuleConditionRepo.GetAllWithIncludeAsync(
            [x => x.ScoringRule, x => x.EventTypeParameter], cancellationToken,
            x => scoringRules.Contains(x.ScoringRuleId)))
            .GroupBy(x => x.ScoringRuleId)
            .ToDictionary(g => g.Key, g => g.ToList());
        Dictionary<int, List<ScoringRuleAction>> scoringRulesActions = (await scoringRuleActionRepo.GetAllWithIncludeAsync(
            [x => x.ScoringRule, x => x.Award, x => x.AmountParameter, x => x.Point], cancellationToken,
            x => scoringRules.Contains(x.ScoringRuleId)))
            .GroupBy(x => x.ScoringRuleId)
            .ToDictionary(g => g.Key, g => g.ToList());

        ScoringAnalysisResponse? scoringEngineResponse = new();
        foreach (int ruleId in scoringRules)
        {
            if (!scoringRulesActions.TryGetValue(ruleId, out var scoringRuleActions) || scoringRuleActions == null || scoringRuleActions.Count == 0)
                continue;

            if (await CheckCondition(new(request, ruleId, scoringRulesConditions), cancellationToken))
            {
                var actionTasks = scoringRuleActions.Select(action =>
                    scoringRuleActionService.DoActionAsync(request, action, cancellationToken)
                        .ContinueWith(t =>
                        {
                            if (t.Exception != null)
                                logger.LogError(t.Exception, "DoScoringRuleActionAsync {message}", t.Exception.Message);
                        }, TaskContinuationOptions.OnlyOnFaulted)
                );
                scoringEngineResponse.ActionCount += actionTasks.Count();
                await Task.WhenAll(actionTasks);
            }
        }
        return scoringEngineResponse;
    }
    
    record ScoringRuleConditionRequest(ScoringAnalysisRequest request, int ruleId,
        Dictionary<int, List<ScoringRuleTriggerCondition>> scoringRulesConditions)
    {
    }
    [Telemetry]
    private async Task<bool> CheckCondition(ScoringRuleConditionRequest request, CancellationToken cancellationToken)
    {
        bool passCondition = false;
        if (!request.scoringRulesConditions.TryGetValue(request.ruleId, out List<ScoringRuleTriggerCondition>? scoringRuleConditions)
            || scoringRuleConditions == null)
        {
            //بدون شرط
            return true;
        }
        else
        {
            foreach (var group in scoringRuleConditions.GroupBy(x => x.ConditionGroup))
            {
                bool passGroup = true;
                foreach (var condition in group)
                {
                    if (!await EvaluateCondition(request, condition, cancellationToken))
                    {
                        passGroup = false;
                        break;
                    }
                }

                if (passGroup)
                {
                    // حداقل یک گروه پاس شد
                    return true;
                }
            }
        }

        return passCondition;
    }

    private async Task<bool> EvaluateCondition(ScoringRuleConditionRequest request, ScoringRuleTriggerCondition condition, CancellationToken cancellationToken)
    {
        if (condition.Kind == ScoringRuleTriggerConditionKind.Formula)
        {
            return await CheckFormula(request, condition, cancellationToken);
        }
        object? compareValue = await CalculateCompareValue(request, condition, cancellationToken);
        return await Compare(condition, compareValue, cancellationToken);
    }

    private async Task<bool> CheckFormula(ScoringRuleConditionRequest request, ScoringRuleTriggerCondition condition, CancellationToken cancellationToken)
    {
        if (condition.Constraint == null)
        {
            throw new ArgumentException(nameof(condition.Constraint));
        }

        if (request.request.Parameters != null)
        {
            object eval = await evaluateFormulaService.Evaluate(condition.EventTypeId, condition.Constraint, request.request.Parameters, cancellationToken);
            return Convert.ToBoolean(eval);
        }
        else
        {
            return Convert.ToBoolean(evaluateFormulaService.Evaluate(condition.Constraint));
        }
    }

    private async Task<object?> CalculateCompareValue(ScoringRuleConditionRequest request, ScoringRuleTriggerCondition condition, CancellationToken cancellationToken)
    {
        object? compareValue = null;
        switch (condition.CompareWith)
        {
            case ScoringRuleTriggerConditionCompareWith.Point:
                if (condition.PointId == null)
                {
                    throw new ArgumentNullException(nameof(condition.PointId));
                }
                compareValue = await customerService.GetPointBalanceAsync(condition.ScoringRule.TenantId,
                    condition.PointId.Value, request.request.Customer.Id, cancellationToken);
                break;
            case ScoringRuleTriggerConditionCompareWith.Parameter:
                if (condition.EventTypeParameter == null)
                {
                    throw new ArgumentNullException(nameof(condition.EventTypeParameter));
                }

                compareValue = request.request.Parameters != null &&
                    request.request.Parameters.TryGetValue(condition.EventTypeParameter.Key, out string? paramValue) && paramValue != null
                    ? (object)paramValue
                    : throw new ArgumentNullException(nameof(condition.EventTypeParameter.Key));
                break;
        }

        return compareValue;
    }

    private async Task<bool> Compare(ScoringRuleTriggerCondition condition, object? compareValue, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "_x", compareValue?.ToString() ?? "" },
            { "_y", condition.Value?.ToString() ?? "" }
        };
        string formula;
        switch (condition.Kind)
        {
            case ScoringRuleTriggerConditionKind.EqualTo:
                formula = "_x == _y"; break;
            case ScoringRuleTriggerConditionKind.NotEqualTo:
                formula = "_x != _y"; break;
            case ScoringRuleTriggerConditionKind.GreaterThan:
                formula = "_x > _y"; break;
            case ScoringRuleTriggerConditionKind.LessThan:
                formula = "_x < _y"; break;
            case ScoringRuleTriggerConditionKind.GreaterThanOrEqualTo:
                formula = "_x >= _y"; break;
            case ScoringRuleTriggerConditionKind.LessThanOrEqualTo:
                formula = "_x <= _y"; break;
            default:
                return false;
        }
        return Convert.ToBoolean(await evaluateFormulaService.Evaluate(condition.EventTypeId, formula, parameters, cancellationToken));
    }
}
