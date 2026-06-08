using Microsoft.EntityFrameworkCore;
using WebWarriors.Aquanetix.Platform.Monitoring.Domain.Model.Aggregates;

namespace WebWarriors.Aquanetix.Platform.Monitoring.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyMonitoringConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Alert>().HasKey(a => a.Id);
        builder.Entity<Alert>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Alert>().Property(a => a.DeviceId).IsRequired();
        builder.Entity<Alert>().Property(a => a.DeviceName).IsRequired().HasMaxLength(100);
        builder.Entity<Alert>().Property(a => a.Location).IsRequired().HasMaxLength(150);
        builder.Entity<Alert>().Property(a => a.Type).IsRequired().HasMaxLength(50);
        builder.Entity<Alert>().Property(a => a.Severity).IsRequired().HasMaxLength(20);
        builder.Entity<Alert>().Property(a => a.Message).IsRequired().HasMaxLength(500);
        builder.Entity<Alert>().Property(a => a.Timestamp).IsRequired();
        builder.Entity<Alert>().Property(a => a.Status).IsRequired().HasMaxLength(20);
        builder.Entity<Alert>().Property(a => a.Value).IsRequired();
        builder.Entity<Alert>().Property(a => a.Threshold).IsRequired();
    }
}