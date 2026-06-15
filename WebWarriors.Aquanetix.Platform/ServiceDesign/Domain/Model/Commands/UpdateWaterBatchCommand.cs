namespace WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Model.Commands;

public record UpdateWaterBatchCommand(
    int            Id,
    string         CertificationCode,
    int            DestinationSectorId,
    double         VolumeLiters,
    DateTimeOffset DeliveryTimestamp,
    string         Status,
    string         Source);