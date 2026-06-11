using WebWarriors.Aquanetix.Platform.Monitoring.Domain.Model.Aggregates;
using WebWarriors.Aquanetix.Platform.Monitoring.Interfaces.Rest.Resources;

namespace WebWarriors.Aquanetix.Platform.Monitoring.Interfaces.Rest.Transform;

public static class AlertResourceFromEntityAssembler
{
    public static AlertResource ToResourceFromEntity(Alert entity) =>
        new(entity.Id,
            entity.DeviceId,
            entity.DeviceName,
            entity.Location,
            entity.Type,
            entity.Severity,
            entity.Message,
            entity.Timestamp,
            entity.Status,
            entity.Value,
            entity.Threshold);
}