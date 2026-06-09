using WebWarriors.Aquanetix.Platform.Devices.Domain.Model.Aggregates;
using WebWarriors.Aquanetix.Platform.Devices.Domain.Model.Entities;
using WebWarriors.Aquanetix.Platform.Shared.Domain.Repositories; // <-- IMPORTANTE

namespace WebWarriors.Aquanetix.Platform.Devices.Domain.Repositories;

// REVISA AQUÍ: Debe tener el ": IBaseRepository<Device>"
public interface IDeviceRepository : IBaseRepository<Device>
{
    Task<Device?> FindByIdAsync(int id);
}