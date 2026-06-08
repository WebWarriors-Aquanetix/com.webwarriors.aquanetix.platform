using Microsoft.EntityFrameworkCore;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Model.Aggregates;

namespace WebWarriors.Aquanetix.Platform.ServiceDesign.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyServiceDesignConfiguration(this ModelBuilder builder)
    {
        builder.Entity<WaterBatch>().HasKey(w => w.Id);
        builder.Entity<WaterBatch>().Property(w => w.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<WaterBatch>().Property(w => w.CertificationCode).IsRequired().HasMaxLength(50);
        builder.Entity<WaterBatch>().Property(w => w.DestinationSectorId).IsRequired();
        builder.Entity<WaterBatch>().Property(w => w.VolumeLiters).IsRequired();
        builder.Entity<WaterBatch>().Property(w => w.DeliveryTimestamp).IsRequired();
        builder.Entity<WaterBatch>().Property(w => w.Status).IsRequired().HasMaxLength(20);
        builder.Entity<WaterBatch>().Property(w => w.Source).IsRequired().HasMaxLength(150);
    }
}