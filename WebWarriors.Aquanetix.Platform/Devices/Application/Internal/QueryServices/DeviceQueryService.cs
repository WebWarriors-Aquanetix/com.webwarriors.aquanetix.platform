using WebWarriors.Aquanetix.Platform.Devices.Application.QueryServices;
using WebWarriors.Aquanetix.Platform.Devices.Domain.Model.Aggregates;
using WebWarriors.Aquanetix.Platform.Devices.Domain.Model.Queries;
using WebWarriors.Aquanetix.Platform.Devices.Domain.Repositories;

namespace WebWarriors.Aquanetix.Platform.Devices.Application.Internal.QueryServices;

public class DeviceQueryService(IDeviceRepository deviceRepository) : IDeviceQueryService
{
    public async Task<Device?> Handle(GetDeviceByIdQuery query, CancellationToken cancellationToken)
    {
        return await deviceRepository.GetDeviceByIdQuery(query.DeviceId, cancellationToken);
    }
}