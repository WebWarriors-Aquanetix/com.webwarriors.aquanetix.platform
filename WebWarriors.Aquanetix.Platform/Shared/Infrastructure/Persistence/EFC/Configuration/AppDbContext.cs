using Microsoft.EntityFrameworkCore;
using WebWarriors.Aquanetix.Platform.Devices.Infrastructure.Persistence.EFC.Configuration.Extensions;
using WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Persistence.EFC.Interceptors;

namespace WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddInterceptors(new AuditableEntityInterceptor());
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Convención snake_case va PRIMERO
        builder.UseSnakeCaseNamingConvention();

        // Devices BC
        builder.ApplyDevicesConfiguration();

        // TODO: builder.ApplyMonitoringConfiguration();
        // TODO: builder.ApplyServiceDesignConfiguration();
        // TODO: builder.ApplyDashboardConfiguration();
    }
}