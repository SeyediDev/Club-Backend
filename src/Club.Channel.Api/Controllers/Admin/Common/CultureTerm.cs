using Neo.Domain.Features.Client;

namespace Club.Web.Controllers.Admin.Common;

[Tags("admin/culture-term")]
[AppRoute("admin", "culture-term")]
public class CultureTermController : GenericCrudControllerBase<CultureTermDto, CultureTerm, int>
{
    [ProducesResponseType(typeof(GetAllGenericEntityResponse<CultureTermDto, int>), StatusCodes.Status200OK)]
    public override async Task<Results<Ok<GetAllGenericEntityResponse<CultureTermDto, int>>, NotFound>> GetAllAsync(
        IGetAllGenericEntityCommandHandler<CultureTermDto, CultureTerm, int> handler,
        ICultureTermQueryRepository cultureTermRepository,
        int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(handler, cultureTermRepository, pageNumber, pageSize, cancellationToken);
    }

    [ProducesResponseType(typeof(CultureTermDto), StatusCodes.Status200OK)]
    public override async Task<Results<Ok<CultureTermDto>, NotFound>> GetByIdAsync(
        IGetGenericEntityCommandHandler<CultureTermDto, CultureTerm, int> handler,
        ICultureTermQueryRepository cultureTermRepository,
        int id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(handler, cultureTermRepository, id, cancellationToken);
    }

    [ProducesResponseType(typeof(CultureTermDto), StatusCodes.Status200OK)]
    public override async Task<Results<Created<CultureTermDto>, BadRequest>> CreateAsync(
        ICreateGenericEntityCommandHandler<CultureTermDto, CultureTerm, int> handler,
        IRequesterUser requesterUser,
        ICommandRepository<CultureTerm, int> cultureTermCommandRepository,
        ICultureTermQueryRepository cultureTermRepository,
        [FromBody] CultureTermDto dto, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(handler, requesterUser,
            cultureTermCommandRepository, cultureTermRepository, dto, cancellationToken);
    }

    [ProducesResponseType(typeof(NoContent), StatusCodes.Status200OK)]
    public override async Task<Results<NoContent, NotFound, BadRequest>> UpdateAsync(
        IUpdateGenericEntityCommandHandler<CultureTermDto, CultureTerm, int> handler,
        IRequesterUser requesterUser,
        ICommandRepository<CultureTerm, int> cultureTermCommandRepository,
        ICultureTermQueryRepository cultureTermRepository,
        int? id, [FromBody] CultureTermDto dto, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(handler, requesterUser, cultureTermCommandRepository, cultureTermRepository,
            id, dto, cancellationToken);
    }

    [ProducesResponseType(typeof(NoContent), StatusCodes.Status200OK)]
    public override async Task<Results<NoContent, NotFound, BadRequest>> DeleteAsync(
        IDeleteGenericEntityCommandHandler<CultureTerm, int> handler,
        ICultureTermQueryRepository cultureTermRepository,
        ICommandRepository<CultureTerm, int> cultureTermCommandRepository,
        int id, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(handler, cultureTermRepository, cultureTermCommandRepository, id, cancellationToken);
    }
}

public record CultureTermDto : BaseDto<int>
{
    public string SubjectTitle { get; set; } = null!;
    public int SubjectId { get; set; }
    public string SubjectField { get; set; } = null!;
    public int LanghageId { get; set; }
    public string Term { get; set; } = null!;
}
