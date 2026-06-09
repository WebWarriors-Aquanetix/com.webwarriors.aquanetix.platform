using Microsoft.EntityFrameworkCore;
using WebWarriors.Aquanetix.Platform.Devices.Domain.Model.Aggregates;

namespace WebWarriors.Aquanetix.Platform.Devices.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyDevicesConfiguration(this ModelBuilder builder)
    {
        // Esto le dice a Entity Framework que mapee la entidad Device
        builder.Entity<Device>().HasKey(d => d.Id);
        
        // Aquí puedes agregar más configuraciones si tu entidad las requiere, por ejemplo:
        // builder.Entity<Device>().Property(d => d.Id).ValueGeneratedOnAdd();
    }
}