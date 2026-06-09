namespace WebWarriors.Aquanetix.Platform.ServiceDesign.Interfaces.Rest.Resources;

public record CreateWaterBatchResource(
    string         CertificationCode,
    int            DestinationSectorId,
    double         VolumeLiters,
    DateTimeOffset DeliveryTimestamp,
    string         Status,
    string         Source
    );