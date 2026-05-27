using Microsoft.EntityFrameworkCore;
using WebWarriors.Aquanetix.Platform.Shared.Domain.Model.Aggregates;
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
        
        builder.Entity<Analysis>().HasKey(a => a.Id);
        builder.Entity<Analysis>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Analysis>().Property(a => a.SensorSourceId).IsRequired();
        builder.Entity<Analysis>().Property(a => a.DetectedParameters).IsRequired();
        builder.Entity<Analysis>().Property(a => a.AnomalyStatus).IsRequired();
        builder.Entity<Analysis>().Property(a => a.SeverityScore).IsRequired();
        
        builder.UseSnakeCaseNamingConvention();
    }
}