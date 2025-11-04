using Club.Domain.Entities.Customers.Enums;
using Club.Domain.Entities.Points.Enums;

namespace Club.Domain.Features.ScoringRules;

public interface IScoringRuleActionService
{
    [Telemetry]
    Task DoActionAsync(ScoringAnalysisRequest data, ScoringRuleAction action, CancellationToken cancellationToken);
}

internal class ScoringRuleActionService(
    IAwardAssetInternalService awardAssetInternalService, 
    IPointBudgetService pointBudgetService, 
    ISmsService smsService,
    IEvaluateFormulaService evaluateFormulaService, 
    IPointLevelService pointLevelService,
    ICommandRepository<CustomerTransaction, long> customerTransactionCmdRepo,
    ICommandRepository<CustomerParameterValue, int> customerParameterValueCmdRepo,
    ICommandRepository<CustomerSegmentMembership, int> customerSegmentMembershipCmdRepo,
    ICommandRepository<CustomerReferrer, int> customerReferrerCmdRepo,
    IQueryRepository<ReferrerCode, int> referrerCodeRepo,
    ILogger<ScoringRuleActionService> logger
    ) : IScoringRuleActionService
{
    public async Task DoActionAsync(ScoringAnalysisRequest request,
        ScoringRuleAction action, CancellationToken cancellationToken)
    {
        string? value = await ExtractValueAsync(request, action, cancellationToken);
        switch (action.ActionOnWho)
        {
            case ScoringRuleActionOnWho.Customer:
                await DoActionPerCustomerAsync(request, action, request.Customer, value, cancellationToken);
                break;
            case ScoringRuleActionOnWho.Referrer:
            case ScoringRuleActionOnWho.Both:
                Customer? referrer = await GetReferrer(request.Customer.Id, cancellationToken);
                if (referrer != null ) 
                {
                    await DoActionPerCustomerAsync(request, action, referrer, value, cancellationToken);
                }
                if (action.ActionOnWho == ScoringRuleActionOnWho.Both)
                {
                    await DoActionPerCustomerAsync(request, action, request.Customer, value, cancellationToken);
                }
                break;
        }
    }

    private async Task<Customer?> GetReferrer(int customerId, CancellationToken cancellationToken)
    {
        var r = await customerReferrerCmdRepo.FirstOrDefaultWithIncludeAsync(
            x => x.ReferrerCustomer,
            x => x.ReferredCustomerId == customerId, cancellationToken);
        return r?.ReferrerCustomer;
    }

    private async Task DoActionPerCustomerAsync(ScoringAnalysisRequest request,
        ScoringRuleAction action, Customer customer, string? value, CancellationToken cancellationToken)
    {
        long longValue = value?.ToInt64OrDefault() ?? 0;
        switch (action.ActionKind)
        {
            case ScoringRuleActionKind.CreditPoint or ScoringRuleActionKind.DebitPoint or ScoringRuleActionKind.SetPointBalance:
                await SetPointBaseAction(request, action, customer, longValue, cancellationToken);
                break;
            case ScoringRuleActionKind.SetCustomerParameterValue:
                if (value != null)
                {
                    await SetCustomerParameterValue(request, action, customer, value, cancellationToken);
                }
                break;
            case ScoringRuleActionKind.JoinInCustomerSegment:
                await JoinInCustomerSegment(request, action, customer, cancellationToken);
                break;
            case ScoringRuleActionKind.ReferrerRegistration:
                if (value != null)
                { 
                    await ProcessReferrerRegistration(request, action, customer, value, cancellationToken); 
                }
                break;
            case ScoringRuleActionKind.GrantProduct:
                await GrantProduct(request, action, customer, longValue, cancellationToken);
                break;
        }
        switch (action.NotificationMethod)
        {
            case ScoringRuleNotificationMethod.SendSms:
                await SendSms(request, action, customer, cancellationToken);
                break;
            case ScoringRuleNotificationMethod.SendNotification:
                await SendNotification(request, action, customer, cancellationToken);
                break;
            case ScoringRuleNotificationMethod.Both:
                await SendSms(request, action, customer, cancellationToken);
                await SendNotification(request, action, customer, cancellationToken);
                break;
        }
    }

    private async Task SendNotification(ScoringAnalysisRequest request, ScoringRuleAction action, Customer customer, CancellationToken cancellationToken)
    {
        string? notification = (await evaluateFormulaService.Evaluate(
            request.EventTypeId, action.MessageTemplate!, request.Parameters!, cancellationToken))?.ToString();
        if (customer.MobileNo != null && notification != null)
        {
            //TODO send notification
            await smsService.SendAsync(new(customer.MobileNo!, notification!));
        }
        logger.LogInformation("SendNotification {customer} {template} {notification}", customer.NationalCode, action.MessageTemplate, notification);
    }

    private async Task SendSms(ScoringAnalysisRequest request, ScoringRuleAction action, Customer customer, CancellationToken cancellationToken)
    {
        string? sms = (await evaluateFormulaService.Evaluate(
            request.EventTypeId, action.MessageTemplate!, request.Parameters!, cancellationToken))?.ToString();
        if (customer.MobileNo != null && sms != null)
        {
            await smsService.SendAsync(new(customer.MobileNo!, sms!));
        }
        logger.LogInformation("SendSms {customer} {mobileNo} {template} {sms}",
            customer.NationalCode, customer.MobileNo, action.MessageTemplate, sms);
    }

    private async Task SetPointBaseAction(
        ScoringAnalysisRequest request, ScoringRuleAction action,
        Customer customer, long value, CancellationToken cancellationToken)
    {
        logger.LogInformation("1.SetPointBaseAction({@request} {@action} {value})", request, action, value);
        if (action.PointId == null)
        {
            throw new ArgumentNullException(nameof(action.PointId));
        }

        CustomerTransaction? lastCustomerTransaction = await customerTransactionCmdRepo.FirstOrDefaultAsync(
            x => x.TenantId == action.ScoringRule.TenantId &&
                 x.CustomerId == customer.Id &&
                 x.PointId == action.PointId, cancellationToken);
        CustomerTransaction customerTransaction = new()
        {
            TenantId = action.ScoringRule.TenantId,
            CustomerId = customer.Id,
            Customer = customer,
            PointId = action.PointId.Value,
            Point = action.Point!,
            EventLogId = request.EventLogId,
            ScoringRuleId = action.ScoringRuleId,
            ScoringRuleActionId = action.Id,
        };
        switch (action.ActionKind)
        {
            case ScoringRuleActionKind.CreditPoint:
                if (!await pointBudgetService.HasBudget(action.ScoringRule.TenantId, action.PointId.Value,
                    value, customer, request.CustomerPointLevels, cancellationToken))
                {
                    logger.LogInformation("2.SetPointBaseAction({@request} {@action} {value})", request, action, value);
                    return;
                }
                customerTransaction.TransactionType = CustomerTransactionType.Credit;
                customerTransaction.Credit = value;
                await SetNewPointBalance(customerTransaction, (lastCustomerTransaction?.Balance ?? 0) + value, cancellationToken);
                break;
            case ScoringRuleActionKind.DebitPoint:
                customerTransaction.TransactionType = CustomerTransactionType.Debit;
                customerTransaction.Debit = value;
                await SetNewPointBalance(customerTransaction, (lastCustomerTransaction?.Balance ?? 0) - value, cancellationToken);
                break;
            case ScoringRuleActionKind.SetPointBalance:
                long oldBalance = lastCustomerTransaction?.Balance ?? 0;
                if (value - oldBalance >= 0)
                {
                    if (!await pointBudgetService.HasBudget(action.ScoringRule.TenantId, action.PointId.Value,
                        value - oldBalance, customer, request.CustomerPointLevels, cancellationToken))
                    {
                        logger.LogInformation("3.SetPointBaseAction({@request} {@action} {value})", request, action, value - oldBalance);
                        return;
                    }
                    customerTransaction.TransactionType = CustomerTransactionType.Credit;
                    customerTransaction.Credit = value - oldBalance;
                }
                else
                {
                    customerTransaction.TransactionType = CustomerTransactionType.Debit;
                    customerTransaction.Debit = oldBalance - value;
                }
                await SetNewPointBalance(customerTransaction, value, cancellationToken);
                break;
        }
        if (lastCustomerTransaction != null)
        {
            lastCustomerTransaction.ExpireDate = new DateTime();
            customerTransactionCmdRepo.Update(lastCustomerTransaction);
        }
        customerTransactionCmdRepo.Add(customerTransaction);
    }

    private async Task SetNewPointBalance(
        CustomerTransaction customerTransaction, long balance, CancellationToken cancellationToken)
    {
        if (customerTransaction.Balance != balance && customerTransaction.Point.PointType == PointType.Xp)
        {
            //TODO Job
            var r = await pointLevelService.CheckAndUpdateLevel(
                new CheckPointLevelRequest(
                    customerTransaction.PointId,
                    customerTransaction.Customer.Id,
                    balance,
                    customerTransaction.EventLogId
                ), cancellationToken);
            //foreach (var pointLevelId in r.NewPointLevelIds)
            //{
            //    //Trigger UpgradePointLevel Event
            //    EventResponse eventResponse = (await eventService.RecordEventAsync(
            //        new(TriggerType.UpgradePointLevel, customerTransaction.Customer?.NationalCode?.ToString()?.PadLeft(10, '0') ?? "---", null)
            //        {
            //            PointLevelId = pointLevel?.Id
            //        }, cancellationToken))!;
            //    await scoringRuleService.ScoringAnalysis(
            //        new(TriggerType.UpgradePointLevel, eventResponse.Customer, eventResponse.EventLogId, null)
            //        {
            //            PointLevelId = pointLevel?.Id,
            //        }, cancellationToken);
            //}
        }
        customerTransaction.Balance = balance;
    }

    private async Task SetCustomerParameterValue(
        ScoringAnalysisRequest request, ScoringRuleAction action, 
        Customer customer, string value, CancellationToken cancellationToken)
    {
        if(action.CustomerParameterId==null)
        {
            throw new ArgumentNullException(nameof(action.CustomerParameterId));
        }
        CustomerParameterValue? customerParameterValue = await customerParameterValueCmdRepo.FirstOrDefaultAsync(
            x => x.ParameterId == action.CustomerParameterId, cancellationToken);
        if (customerParameterValue != null) 
        {
            if (customerParameterValue.Value == value)
            { 
                return; 
            }
            customerParameterValue.ExpireDate = DateTime.Now;
            customerParameterValue.IsDeleted = true;
            customerParameterValueCmdRepo.Update(customerParameterValue);
            await customerParameterValueCmdRepo.UnitOfWork.SaveChangesAsync();
        }
        customerParameterValue = new()
        {
            CustomerId = customer.Id,
            ParameterId = action.CustomerParameterId.Value,
            EventLogId = request.EventLogId,
            Value = value,
        };
        customerParameterValueCmdRepo.Add(customerParameterValue);
        await customerParameterValueCmdRepo.UnitOfWork.SaveChangesAsync();
    }

    private async Task JoinInCustomerSegment(
        ScoringAnalysisRequest request, ScoringRuleAction action, 
        Customer customer, CancellationToken cancellationToken)
    {
        if (action.CustomerSegmentId == null)
        {
            throw new ArgumentNullException(nameof(action.CustomerSegmentId));
        }
        CustomerSegmentMembership? customerSegmentMembership = await customerSegmentMembershipCmdRepo.FirstOrDefaultAsync(
            x => x.SegmentId == action.CustomerSegmentId, cancellationToken);
        if (customerSegmentMembership == null)
        {
            customerSegmentMembership = new()
            {
                CustomerId = customer.Id,
                SegmentId = action.CustomerSegmentId.Value,
                EventLogId = request.EventLogId
            };
            customerSegmentMembershipCmdRepo.Add(customerSegmentMembership);
            await customerSegmentMembershipCmdRepo.UnitOfWork.SaveChangesAsync();
        }
    }

    private async Task GrantProduct(
        ScoringAnalysisRequest request, ScoringRuleAction action, 
        Customer customer, long value, CancellationToken cancellationToken)
    {
        if (action.AwardId == null || action.Award == null)
        {
            throw new ArgumentNullException(nameof(action.AwardId));
        }
        if (value == 0)
        {
            value = 1;
        }

        await awardAssetInternalService.Create(action.Award, customer, request.EventLogId, action.ScoringRuleId, action.Id, (int)value, cancellationToken);
    }

    private async Task<string?> ExtractValueAsync(
        ScoringAnalysisRequest request, ScoringRuleAction action, CancellationToken cancellationToken)
    {
        string? value = null;
        switch (action.AmountMethod)
        {
            case ScoringRuleActionAmountMethod.FixAmount:
                value = action.Amount;
                break;
            case ScoringRuleActionAmountMethod.FromParameter:
                if (action.AmountParameter == null || action.AmountParameterId != null)
                {
                    throw new ArgumentException(nameof(action.AmountParameter));
                }
                if (request.Parameters != null && request.Parameters.TryGetValue(action.AmountParameter.Key.ToString(), out string? paramValue) && paramValue != null)
                {
                    value = paramValue;
                }

                break;
            case ScoringRuleActionAmountMethod.FromFormula:
                {
                    if (action.AmountFormula == null)
                    {
                        throw new ArgumentException(nameof(action.AmountFormula));
                    }
                    if (request.Parameters != null)
                    {
                        object result = await evaluateFormulaService.Evaluate(request.EventTypeId??0, action.AmountFormula, request.Parameters, cancellationToken);
                        value = result?.ToString();
                    }
                    else
                    {
                        value = evaluateFormulaService.Evaluate(action.AmountFormula)?.ToString();
                    }
                }
                break;
        }

        return value;
    }

    private async Task ProcessReferrerRegistration(
        ScoringAnalysisRequest request, ScoringRuleAction action, 
        Customer customer, string code, CancellationToken cancellationToken)
    {
        ReferrerCode? referrerCode = await referrerCodeRepo.FirstOrDefaultAsync(x=>x.Code== code, cancellationToken);
        if(referrerCode!=null)
        {
            CustomerReferrer? customerReferrer = await customerReferrerCmdRepo.FirstOrDefaultAsync(
                x => x.ReferredCustomerId == customer.Id &&
                     x.ReferrerCustomerId == referrerCode.CustomerId
                , cancellationToken);
            if (customerReferrer != null)
            {
                return;
            }
            customerReferrer = new()
            {
                ReferrerCustomerId = referrerCode.CustomerId,
                ReferredCustomerId = customer.Id,
                ReferrerCodeId = referrerCode.Id,
                EventLogId = request.EventLogId,
                TenantId = action.ScoringRule?.TenantId??0,
            };
            customerReferrerCmdRepo.Add(customerReferrer);
            await customerReferrerCmdRepo.UnitOfWork.SaveChangesAsync();
        }
    }
}