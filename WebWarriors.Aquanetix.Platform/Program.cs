using Cortex.Mediator.Commands;
using Cortex.Mediator.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.OpenApi;
using WebWarriors.Aquanetix.Platform.Devices.Application.CommandServices;
using WebWarriors.Aquanetix.Platform.Devices.Application.Internal.CommandServices;
using WebWarriors.Aquanetix.Platform.Devices.Application.Internal.QueryServices;
using WebWarriors.Aquanetix.Platform.Devices.Application.QueryServices;
using WebWarriors.Aquanetix.Platform.Devices.Domain.Repositories;
using WebWarriors.Aquanetix.Platform.Devices.Infrastructure.Persistence.EFC.Repositories;
using WebWarriors.Aquanetix.Platform.Shared.Domain.Repositories;
using WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Interfaces.ASP.Configuration;
using WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Mediator.Cortex.Configuration;
using WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Pipeline.Middleware.Extensions;
using WebWarriors.Aquanetix.Platform.Shared.Resources;
using WebWarriors.Aquanetix.Platform.Shared.Resources.Errors;
using ProblemDetailsFactory =
    WebWarriors.Aquanetix.Platform.Shared.Interfaces.Rest.ProblemDetails.ProblemDetailsFactory;

var builder = WebApplication.CreateBuilder(args);

// ── Routing & Controllers ──────────────────────────────────────────────────
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services
    .AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()))
    .AddDataAnnotationsLocalization();

builder.Services.AddProblemDetails();

// ── CORS ───────────────────────────────────────────────────────────────────
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// ── Database ───────────────────────────────────────────────────────────────
builder.Services.AddDbContext<AppDbContext>((serviceProvider, options) =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    if (string.IsNullOrWhiteSpace(connectionString))
        throw new InvalidOperationException("Connection string is not configured.");

    options.UseMySQL(connectionString)
        .UseLoggerFactory(serviceProvider.GetRequiredService<ILoggerFactory>())
        .EnableDetailedErrors();

    if (builder.Environment.IsDevelopment())
        options.EnableSensitiveDataLogging();
});

// ── Localización ───────────────────────────────────────────────────────────
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddSingleton<IStringLocalizer<ErrorMessages>, StringLocalizer<ErrorMessages>>();
builder.Services.AddSingleton<IStringLocalizer<CommonMessages>, StringLocalizer<CommonMessages>>();

// ── ProblemDetails & Swagger ───────────────────────────────────────────────
builder.Services.AddSingleton<ProblemDetailsFactory>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title       = "WebWarriors.Aquanetix.Platform",
        Version     = "v1",
        Description = "Aquanetix IoT Water Quality Monitoring Platform API"
    });
    options.EnableAnnotations();
});

// ── Dependency Injection ───────────────────────────────────────────────────
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Devices BC
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IDeviceQueryService, DeviceQueryService>();
builder.Services.AddScoped<IDeviceCommandService, DeviceCommandService>();

// ── Mediator ───────────────────────────────────────────────────────────────
builder.Services.AddScoped(typeof(ICommandPipelineBehavior<>), typeof(LoggingCommandBehavior<>));
builder.Services.AddCortexMediator([typeof(Program)]);

var app = builder.Build();

// ── Migraciones automáticas ────────────────────────────────────────────────
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}

// ── Pipeline ───────────────────────────────────────────────────────────────
app.UseGlobalExceptionHandler();

var supportedCultures = new[] { "en", "es" };
app.UseRequestLocalization(new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures));

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
