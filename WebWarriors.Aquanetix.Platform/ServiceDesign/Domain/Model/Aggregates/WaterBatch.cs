using WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Model.Commands;
using WebWarriors.Aquanetix.Platform.Shared.Domain.Model.Entities;

namespace WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Model.Aggregates;

/// <summary>
///     Aggregate root representing a certified water batch
///     within the Service Design and Planning Bounded Context.
/// </summary>
public class WaterBatch : IAuditableEntity
{
    public WaterBatch() { }

    public WaterBatch(CreateWaterBatchCommand command) : this()
    {
        CertificationCode   = command.CertificationCode;
        DestinationSectorId = command.DestinationSectorId;
        VolumeLiters        = command.VolumeLiters;
        DeliveryTimestamp   = command.DeliveryTimestamp;
        Status              = command.Status;
        Source              = command.Source;
    }

    public int    Id                  { get; private set; }
    public string CertificationCode   { get; private set; } = string.Empty;
    public int    DestinationSectorId { get; private set; }
    public double VolumeLiters        { get; private set; }
    public DateTimeOffset DeliveryTimestamp { get; private set; }

    /// <summary>Pending | Delivered | Cancelled</summary>
    public string Status { get; private set; } = string.Empty;
    public string Source { get; private set; } = string.Empty;

    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}