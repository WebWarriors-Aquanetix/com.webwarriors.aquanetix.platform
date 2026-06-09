using WebWarriors.Aquanetix.Platform.Devices.Domain.Model.Aggregates;
using WebWarriors.Aquanetix.Platform.Devices.Domain.Model.Queries;

namespace WebWarriors.Aquanetix.Platform.Devices.Application.QueryServices;

public interface IDeviceQueryService
{
    /// <summary>
    ///     Handle get device by id
    /// </summary>
    /// <param name="query">
    ///     The <see cref="GetDeviceByIdQuery" /> query
    /// </param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///  <A <see cref="Device"/> object or null /returns>
    Task<Device?> Handle(GetDeviceByIdQuery query, CancellationToken cancellationToken);
}