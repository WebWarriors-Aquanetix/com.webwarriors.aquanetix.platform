using WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Model.Commands;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Interfaces.Rest.Resources;

namespace WebWarriors.Aquanetix.Platform.ServiceDesign.Interfaces.Rest.Transform;

public static class UpdateWaterBatchCommandFromResourceAssembler
{
    public static UpdateWaterBatchCommand ToCommandFromResource(UpdateWaterBatchResource resource, int waterBatchId) =>
        new(waterBatchId,
            resource.CertificationCode,
            resource.DestinationSectorId,
            resource.VolumeLiters,
            resource.DeliveryTimestamp,
            resource.Status,
            resource.Source);
}