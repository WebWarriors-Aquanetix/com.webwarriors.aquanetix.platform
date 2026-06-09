using Microsoft.EntityFrameworkCore;
using WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using WebWarriors.Aquanetix.Platform.Devices.Domain.Repositories;
using WebWarriors.Aquanetix.Platform.Devices.Infrastructure.Persistence.EFC.Repositories;
using WebWarriors.Aquanetix.Platform.Devices.Application.Internal.QueryServices;
using WebWarriors.Aquanetix.Platform.Devices.Application.QueryServices;

var builder = WebApplication.CreateBuilder(args);

// 1. Agregar controladores y servicios base
builder.Services.AddControllers()
    .AddApplicationPart(typeof(WebWarriors.Aquanetix.Platform.Devices.Interfaces.REST.DevicesController).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

// 2. CONECTAR EL APPDBCONTEXT A LA BASE DE DATOS (Añade esta configuración)
// Extrae la cadena de conexión desde tu archivo appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (connectionString != null)
        options.UseMySQL(connectionString); // O .UseMySql(...) / .UseSqlServer(...) según el proveedor que usen
});

// 3. REGISTRO DE TUS DEPENDENCIAS (Las líneas que pusimos antes)
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IDeviceQueryService, DeviceQueryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    // 2. AGREGA ESTAS LÍNEAS (Habilita la interfaz visual en desarrollo)
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aquanetix API v1");
        // Opcional: Si quieres que Swagger cargue directo en la raíz (sin escribir /swagger en la URL)
        // c.RoutePrefix = string.Empty; 
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();