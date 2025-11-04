using Neo.Domain.Features.Telementry;
using Neo.Endpoint.Infrastructure;
using Neo.Infrastructure.Features.Client;
using Neo.Infrastructure.Features.Telementry;
using Club.Application;
using Club.Channel.Application;
using Club.Infrastructure;
using Club.Channel.Api;
using Club.Channel.Api.Middlewares;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<TelemetryOptions>(builder.Configuration.GetSection(nameof(TelemetryOptions)));
builder.Services.AddClubApplicationServices(builder.Configuration);
builder.Services.AddChannelApplicationServices(builder.Configuration);

builder.Services.AddClubInfrastructureServices(builder.Configuration, builder.Environment);
builder.Host.AddCandoSerilog();
builder.Services.AddCandoOpenTelementry(builder.Configuration);
builder.Services.AddCandoAuthentication(builder.Configuration);
builder.Services.AddCandoAuthorization(builder.Configuration);

builder.Services.AddWebServices();

var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    _ = app.UseHsts();
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseRecuringJobs();

app.UseSwaggerUi(settings =>
{
    //settings.SwaggerRoutes.Add(new SwaggerUiRoute("admin", "/api/specification.json"));
    settings.Path = "/api";
    settings.DocumentPath = "/api/specification.json";

});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.UseMiddleware<CorrelationIdMiddleware>();
app.UseMiddleware<UserAgentLoggingMiddleware>();

app.MapFallbackToFile("index.html");

app.UseExceptionHandler(options => { });

app.Map("/", () => Results.Redirect("/api"));

app.MapControllers();

app.Run();

public partial class Program
{
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureServices((context, services) =>
                {
                    // Configure services for NSwag
                    services.Configure<TelemetryOptions>(context.Configuration.GetSection(nameof(TelemetryOptions)));
                    services.AddClubApplicationServices(context.Configuration);
                    services.AddClubInfrastructureServices(context.Configuration, context.HostingEnvironment);
                    services.AddWebServices();
                });
            });
}

