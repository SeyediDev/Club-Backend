using Neo.Domain.Features.Telementry;
using Neo.Infrastructure.Features.Client;
using Neo.Infrastructure.Features.Telementry;
using Club.CallCenter.Api;
using Club.CallCenter.Api.Infrastructure;
using Club.CallCenter.Api.Middlewares;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<TelemetryOptions>(builder.Configuration.GetSection(nameof(TelemetryOptions)));
builder.Services.AddCallCenterInfrastructureServices(builder.Configuration, builder.Environment);

builder.Host.AddNeoSerilog();
builder.Services.AddNeoOpenTelementry(builder.Configuration);
builder.Services.AddNeoAuthentication(builder.Configuration);
builder.Services.AddNeoAuthorization(builder.Configuration);

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
app.UseCors("AllowCallCenter");
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.UseSwaggerUi(settings =>
{
    settings.Path = "/api";
    settings.DocumentPath = "/api/specification.json";
    
    // اضافه کردن لینک مانیتورینگ
    settings.CustomHeadContent = @"
        <script>
            window.addEventListener('load', function() {
                var monitoringLink = document.createElement('a');
                monitoringLink.href = '/monitoring';
                monitoringLink.target = '_blank';
                monitoringLink.className = 'btn';
                monitoringLink.style.cssText = 'position: fixed; top: 10px; right: 10px; z-index: 9999; background: #4CAF50; color: white; padding: 10px 20px; text-decoration: none; border-radius: 4px; font-weight: bold;';
                monitoringLink.textContent = '📊 مانیتورینگ';
                document.body.appendChild(monitoringLink);
            });
        </script>
    ";
});

app.UseMiddleware<CorrelationIdMiddleware>();
app.UseMiddleware<UserAgentLoggingMiddleware>();

app.UseExceptionHandler(options => { });

app.MapControllers();

app.Run();

public partial class Program { }

