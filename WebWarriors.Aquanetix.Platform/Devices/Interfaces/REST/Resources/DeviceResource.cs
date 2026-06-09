namespace WebWarriors.Aquanetix.Platform.Devices.Interfaces.REST.Resources;

public record DeviceResource(
    int Id,
    int OwnerId,
    string SerialNumber,
    string DeviceType,
    string CurrentStatus,
    DateTimeOffset LastTelemetrySync
);