using Microsoft.EntityFrameworkCore;
using WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Persistence.EFC.Interceptors;
using WebWarriors.Aquanetix.Platform.Devices.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
//using WebWarriors.Aquanetix.Platform.Monitoring.Infrastructure.Persistence.EFC.Configuration.Extensions;


/// <summary>
///     Application database context for the Aquanetix Platform.
/// </summary>
/// <param name="options">The options for the database context.</param>
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
        
        //Devices Context
        builder.ApplyDevicesConfiguration();
        
        builder.UseSnakeCaseNamingConvention();
    }
    
    
}