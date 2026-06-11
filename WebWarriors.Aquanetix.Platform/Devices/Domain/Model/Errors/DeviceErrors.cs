using WebWarriors.Aquanetix.Platform.Shared.Domain.Model;

namespace WebWarriors.Aquanetix.Platform.Devices.Domain.Model.Errors;

public static class DeviceErrors
{
    public static readonly Error DeviceNotFound =
        new("Devices.DeviceNotFound", "The specified device was not found.");
}