using WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Model.Commands;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Interfaces.Rest.Resources;

namespace WebWarriors.Aquanetix.Platform.ServiceDesign.Interfaces.Rest.Transform;

public static class CreateWaterBatchCommandFromResourceAssembler
{
    public static CreateWaterBatchCommand ToCommandFromResource(CreateWaterBatchResource resource) =>
        new(resource.CertificationCode,
            resource.DestinationSectorId,
            resource.VolumeLiters,
            resource.DeliveryTimestamp,
            resource.Status,
            resource.Source);
}