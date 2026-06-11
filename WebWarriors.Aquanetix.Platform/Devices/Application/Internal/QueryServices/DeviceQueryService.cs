using WebWarriors.Aquanetix.Platform.Devices.Application.QueryServices;
using WebWarriors.Aquanetix.Platform.Devices.Domain.Model.Aggregates; // O .Entities según tu mapeo
using WebWarriors.Aquanetix.Platform.Devices.Domain.Model.Queries;
using WebWarriors.Aquanetix.Platform.Devices.Domain.Repositories;

namespace WebWarriors.Aquanetix.Platform.Devices.Application.Internal.QueryServices;

public class DeviceQueryService(IDeviceRepository deviceRepository) : IDeviceQueryService
{
    public async Task<Device?> Handle(GetDeviceByIdQuery query, CancellationToken cancellationToken)
    {
        // CORRECCIÓN: Llamamos al método correcto del repositorio (FindByIdAsync)
        return await deviceRepository.FindByIdAsync(query.DeviceId);
    }
}