using WebWarriors.Aquanetix.Platform.Devices.Domain.Model.ValueObjects;

namespace WebWarriors.Aquanetix.Platform.Devices.Domain.Model.Command;

public record CreateDeviceCommand(
    int OwnerId,
    string SerialNumber,
    DeviceType DeviceType,
    DeviceStatus CurrentStatus,
    DateTimeOffset? LastTelemetrySync
    );