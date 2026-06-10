using WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Model.Aggregates;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Interfaces.Rest.Resources;

namespace WebWarriors.Aquanetix.Platform.ServiceDesign.Interfaces.Rest.Transform;

public static class WaterBatchResourceFromEntityAssembler
{
    public static WaterBatchResource ToResourceFromEntity(WaterBatch entity) =>
        new(entity.Id,
            entity.CertificationCode,
            entity.DestinationSectorId,
            entity.VolumeLiters,
            entity.DeliveryTimestamp,
            entity.Status,
            entity.Source);
}