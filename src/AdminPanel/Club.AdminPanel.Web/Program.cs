using Neo.Domain.Features.Telementry;
using Neo.Infrastructure.Features.Telementry;
using Club.AdminPanel.Web;
using Neo.Endpoint.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<TelemetryOptions>(builder.Configuration.GetSection(nameof(TelemetryOptions))); 

builder.Host.UseDefaultServiceProvider(
        (_, options) =>
        {
            options.ValidateOnBuild = true;
            options.ValidateScopes = true;
        });

builder.Host.AddCandoSerilog();
builder.Services.AddClubBpmsServices(builder.Configuration, builder.Environment);

var app = builder.Build();

app.UseClubBpms(builder.Configuration, builder.Environment);
app.UseRecuringJobs();

app.Run();
