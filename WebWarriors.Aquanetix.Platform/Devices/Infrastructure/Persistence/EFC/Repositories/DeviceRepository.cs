using Microsoft.EntityFrameworkCore;
using WebWarriors.Aquanetix.Platform.Devices.Domain.Model.Aggregates;
using WebWarriors.Aquanetix.Platform.Devices.Domain.Model.Entities;
using WebWarriors.Aquanetix.Platform.Devices.Domain.Repositories;
using WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WebWarriors.Aquanetix.Platform.Devices.Infrastructure.Persistence.EFC.Repositories;

// CORRECCIÓN: Se añade 'AppDbContext' como segundo argumento genérico
public class DeviceRepository : BaseRepository<Device>, IDeviceRepository
{
    // El constructor pasa el contexto a la clase base correctamente
    public DeviceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Device?> FindByIdAsync(int id)
    {
        // Al usar la clase base genérica correcta, ya puedes usar 'Context' sin problemas
        return await Context.Set<Device>().FindAsync(id);
    }
}