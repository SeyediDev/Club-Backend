using Neo.Application.Security;
using Neo.Domain.Features.Client;
using Club.Domain.Entities.Common;

namespace Club.Web.Controllers.Admin.Common;

[Tags("admin/faq")]
[AdminRoute("[controller]")]
[Authorize(Roles = "office")]
public class FaqController : GenericCrudControllerBase<FaqDto, Faq, int>
{
    [ProducesResponseType(typeof(GetAllGenericEntityResponse<FaqDto, int>), StatusCodes.Status200OK)]
    public override async Task<Results<Ok<GetAllGenericEntityResponse<FaqDto, int>>, NotFound>> GetAllAsync(
        IGetAllGenericEntityCommandHandler<FaqDto, Faq, int> handler,
        ICultureTermQueryRepository cultureTermRepository,
        int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(handler, cultureTermRepository, pageNumber, pageSize, cancellationToken);
    }

    [ProducesResponseType(typeof(FaqDto), StatusCodes.Status200OK)]
    public override async Task<Results<Ok<FaqDto>, NotFound>> GetByIdAsync(
        IGetGenericEntityCommandHandler<FaqDto, Faq, int> handler,
        ICultureTermQueryRepository cultureTermRepository,
        int id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(handler, cultureTermRepository, id, cancellationToken);
    }

    [ProducesResponseType(typeof(FaqDto), StatusCodes.Status200OK)]
    public override async Task<Results<Created<FaqDto>, BadRequest>> CreateAsync(
        ICreateGenericEntityCommandHandler<FaqDto, Faq, int> handler,
        IRequesterUser requesterUser,
        ICommandRepository<CultureTerm, int> cultureTermCommandRepository,
        ICultureTermQueryRepository cultureTermRepository,
        [FromBody] FaqDto dto, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(handler, requesterUser,
            cultureTermCommandRepository, cultureTermRepository, dto, cancellationToken);
    }

    [ProducesResponseType(typeof(NoContent), StatusCodes.Status200OK)]
    public override async Task<Results<NoContent, NotFound, BadRequest>> UpdateAsync(
        IUpdateGenericEntityCommandHandler<FaqDto, Faq, int> handler,
        IRequesterUser requesterUser,
        ICommandRepository<CultureTerm, int> cultureTermCommandRepository,
        ICultureTermQueryRepository cultureTermRepository,
        int? id, [FromBody] FaqDto dto, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(handler, requesterUser, cultureTermCommandRepository, cultureTermRepository,
            id, dto, cancellationToken);
    }

    [ProducesResponseType(typeof(NoContent), StatusCodes.Status200OK)]
    public override async Task<Results<NoContent, NotFound, BadRequest>> DeleteAsync(
        IDeleteGenericEntityCommandHandler<Faq, int> handler,
        ICultureTermQueryRepository cultureTermRepository,
        ICommandRepository<CultureTerm, int> cultureTermCommandRepository,
        int id, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(handler, cultureTermRepository, cultureTermCommandRepository, id, cancellationToken);
    }
}

public record FaqDto : BaseDto<int>
{
    public string Question { get; set; } = null!;
    public string Answer { get; set; } = null!;
    public int SortIndex { get; set; }
}
