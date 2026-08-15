using System.Security.Claims;
using Microsoft.Extensions.Primitives;
using Neo.Common.Extensions;
using Neo.Domain.Entities.Common;
using Neo.Domain.Features.Client;

namespace Club.CallCenter.Api;

public class CallCenterRequesterUser(IHttpContextAccessor httpContextAccessor)
    : IRequesterUser
{
    private UserId? _id;
    public UserId? Id
    {
        get
        {
            if (_id.HasValue)
            {
                return _id;
            }

            string? claimValue = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? httpContextAccessor.HttpContext?.User?.FindFirstValue("user_id");
            _id = (UserId?)claimValue?.ToNullableInt32();
            return _id;
        }
        set => _id = value;
    }

    public string Platform => "CallCenter";

    private string? _appName;
    public string? AppName
    {
        get
        {
            if (_appName != null)
            {
                return _appName;
            }

            _appName = httpContextAccessor.HttpContext?.Request.Headers.TryGetValue("x-app-name", out StringValues appName) is true
                ? appName.ToString()
                : "CallCenter";
            return _appName;
        }
    }

    private string? _lang;
    public string? Lang
    {
        get
        {
            if (_lang != null)
            {
                return _lang;
            }

            _lang = httpContextAccessor.HttpContext?.Request.Headers.TryGetValue("x-lang", out StringValues lang) is true
                ? lang.ToString()
                : "fa";
            return _lang;
        }
    }

    public Task<LanguageId> GetLangIdAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new LanguageId( Lang == "en" ? 2 : 1));
    }

    private string? _mobile;
    public string? Mobile
    {
        get
        {
            if (_mobile != null)
            {
                return _mobile;
            }

            _mobile = httpContextAccessor.HttpContext?.User?.FindFirstValue("mobile");
            return _mobile;
        }
        set => _mobile = value;
    }

    private string? _correlationId;
    public string? CorrelationId
    {
        get
        {
            if (_correlationId != null)
            {
                return _correlationId;
            }

            _correlationId = httpContextAccessor.HttpContext?.Request.Headers.TryGetValue("X-Correlation-ID", out StringValues correlationId) is true
                ? correlationId.ToString()
                : null;
            return _correlationId;
        }
    }

    private string? _tenantId;
    public string? TenantId
    {
        get
        {
            if (_tenantId != null)
            {
                return _tenantId;
            }

            _tenantId = httpContextAccessor.HttpContext?.Request.Headers.TryGetValue("X-Tenant-Id", out StringValues tenantId) is true
                ? tenantId.ToString()
                : httpContextAccessor.HttpContext?.User?.FindFirstValue("tenant_id");
            return _tenantId;
        }
        set => _tenantId = value;
    }

    public Dictionary<string, object> Properties { get; set; } = [];

    public List<Claim> Claims()
    {
        return httpContextAccessor.HttpContext?.User?.Claims.ToList() ?? [];
    }

    public bool? IsInRole(string role)
    {
        return httpContextAccessor.HttpContext?.User?.IsInRole(role);
    }
}

