using Microsoft.EntityFrameworkCore;
using WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Persistence.EFC.Interceptors;

using WebWarriors.Aquanetix.Platform.Monitoring.Domain.Model.Aggregates;
namespace WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context for the Aquanetix Platform.
/// </summary>
/// <param name="options">The options for the database context.</param>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Alert> Alerts { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddInterceptors(new AuditableEntityInterceptor());
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.UseSnakeCaseNamingConvention(); 
        builder.Entity<Alert>(entity =>
        {
            
            entity.HasKey(a => a.Id);
            
            entity.Property(a => a.Id).ValueGeneratedOnAdd();

            
            entity.Property(a => a.DeviceName).IsRequired().HasMaxLength(100);
            entity.Property(a => a.Location).IsRequired().HasMaxLength(150);
            entity.Property(a => a.Type).IsRequired().HasMaxLength(50);
            entity.Property(a => a.Severity).IsRequired().HasMaxLength(30);
            entity.Property(a => a.Message).IsRequired().HasMaxLength(500);
            entity.Property(a => a.Status).IsRequired().HasMaxLength(30);
        });
    }
}