using Neo.Domain.Features.Telementry;
using Neo.Endpoint.Infrastructure;
using Neo.Infrastructure.Features.Client;
using Neo.Infrastructure.Features.Telementry;
using Club.CustomerPortal.Application;
using Club.Infrastructure;
using Club.CustomerPortal.Api;
using Club.CustomerPortal.Api.Middlewares;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<TelemetryOptions>(builder.Configuration.GetSection(nameof(TelemetryOptions)));
// Note: CustomerPortal uses Club.Infrastructure but has its own Application layer
builder.Services.AddClubInfrastructureServices(builder.Configuration, builder.Environment);
builder.Services.AddCustomerPortalApplicationServices(builder.Configuration);

builder.Host.AddCandoSerilog();
builder.Services.AddCandoOpenTelementry(builder.Configuration);
builder.Services.AddCandoAuthentication(builder.Configuration);
builder.Services.AddCandoAuthorization(builder.Configuration);

builder.Services.AddWebServices(builder.Configuration);

var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseCors("AllowCustomerPortal");
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseRecuringJobs();

app.UseSwaggerUi(settings =>
{
    settings.Path = "/api";
    settings.DocumentPath = "/api/specification.json";
});

app.UseMiddleware<CorrelationIdMiddleware>();
app.UseMiddleware<UserAgentLoggingMiddleware>();

app.UseExceptionHandler(options => { });

app.MapControllers();

app.Run();

public partial class Program { }

