namespace WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Model.Commands;

public record CreateWaterBatchCommand(
    string        CertificationCode,
    int           DestinationSectorId,
    double        VolumeLiters,
    DateTimeOffset DeliveryTimestamp,
    string        Status,
    string        Source
    );