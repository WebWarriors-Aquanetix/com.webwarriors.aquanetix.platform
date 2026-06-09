using Microsoft.EntityFrameworkCore;
using WebWarriors.Aquanetix.Platform.Monitoring.Domain.Model.Aggregates;

namespace WebWarriors.Aquanetix.Platform.Monitoring.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyMonitoringConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Alert>().ToTable("alerts");
        builder.Entity<Alert>().HasKey(a => a.Id);
        builder.Entity<Alert>().Property(a => a.Id)
            .HasColumnName("id").IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Alert>().Property(a => a.DeviceId)
            .HasColumnName("device_id").IsRequired();
        builder.Entity<Alert>().Property(a => a.DeviceName)
            .HasColumnName("device_name").IsRequired().HasMaxLength(100);
        builder.Entity<Alert>().Property(a => a.Location)
            .HasColumnName("location").IsRequired().HasMaxLength(150);
        builder.Entity<Alert>().Property(a => a.Type)
            .HasColumnName("type").IsRequired().HasMaxLength(50);
        builder.Entity<Alert>().Property(a => a.Severity)
            .HasColumnName("severity").IsRequired().HasMaxLength(20);
        builder.Entity<Alert>().Property(a => a.Message)
            .HasColumnName("message").IsRequired().HasMaxLength(500);
        builder.Entity<Alert>().Property(a => a.Timestamp)
            .HasColumnName("timestamp").IsRequired();
        builder.Entity<Alert>().Property(a => a.Status)
            .HasColumnName("status").IsRequired().HasMaxLength(20);
        builder.Entity<Alert>().Property(a => a.Value)
            .HasColumnName("value").IsRequired();
        builder.Entity<Alert>().Property(a => a.Threshold)
            .HasColumnName("threshold").IsRequired();
        builder.Entity<Alert>().Property(a => a.CreatedAt)
            .HasColumnName("created_at");
        builder.Entity<Alert>().Property(a => a.UpdatedAt)
            .HasColumnName("updated_at");
    }
}