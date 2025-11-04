using Neo.Application.Security;
using Neo.Domain.Features.Client;
using Club.Domain.Entities.Common;

namespace Club.Web.Controllers.Admin.Common;

[Tags("admin/help")]
[AdminRoute("[controller]")]
[Authorize(Roles = "office")]
public class HelpController : GenericCrudControllerBase<HelpDto, Help, int>
{
    [ProducesResponseType(typeof(GetAllGenericEntityResponse<HelpDto, int>), StatusCodes.Status200OK)]
    public override async Task<Results<Ok<GetAllGenericEntityResponse<HelpDto, int>>, NotFound>> GetAllAsync(
        IGetAllGenericEntityCommandHandler<HelpDto, Help, int> handler,
        ICultureTermQueryRepository cultureTermRepository,
        int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(handler, cultureTermRepository, pageNumber, pageSize, cancellationToken);
    }

    [ProducesResponseType(typeof(HelpDto), StatusCodes.Status200OK)]
    public override async Task<Results<Ok<HelpDto>, NotFound>> GetByIdAsync(
        IGetGenericEntityCommandHandler<HelpDto, Help, int> handler,
        ICultureTermQueryRepository cultureTermRepository,
        int id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(handler, cultureTermRepository, id, cancellationToken);
    }

    [ProducesResponseType(typeof(HelpDto), StatusCodes.Status200OK)]
    public override async Task<Results<Created<HelpDto>, BadRequest>> CreateAsync(
        ICreateGenericEntityCommandHandler<HelpDto, Help, int> handler,
        IRequesterUser requesterUser,
        ICommandRepository<CultureTerm, int> cultureTermCommandRepository,
        ICultureTermQueryRepository cultureTermRepository,
        [FromBody] HelpDto dto, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(handler, requesterUser,
            cultureTermCommandRepository, cultureTermRepository, dto, cancellationToken);
    }

    [ProducesResponseType(typeof(NoContent), StatusCodes.Status200OK)]
    public override async Task<Results<NoContent, NotFound, BadRequest>> UpdateAsync(
        IUpdateGenericEntityCommandHandler<HelpDto, Help, int> handler,
        IRequesterUser requesterUser,
        ICommandRepository<CultureTerm, int> cultureTermCommandRepository,
        ICultureTermQueryRepository cultureTermRepository,
        int? id, [FromBody] HelpDto dto, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(handler, requesterUser, cultureTermCommandRepository, cultureTermRepository,
            id, dto, cancellationToken);
    }

    [ProducesResponseType(typeof(NoContent), StatusCodes.Status200OK)]
    public override async Task<Results<NoContent, NotFound, BadRequest>> DeleteAsync(
        IDeleteGenericEntityCommandHandler<Help, int> handler,
        ICultureTermQueryRepository cultureTermRepository,
        ICommandRepository<CultureTerm, int> cultureTermCommandRepository,
        int id, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(handler, cultureTermRepository, cultureTermCommandRepository, id, cancellationToken);
    }
}

public record HelpDto : BaseDto<int>
{
    public string Content { get; set; } = null!;
}
