using WebWarriors.Aquanetix.Platform.Monitoring.Domain.Model.Commands;
using WebWarriors.Aquanetix.Platform.Shared.Domain.Model.Entities;

namespace WebWarriors.Aquanetix.Platform.Monitoring.Domain.Model.Aggregates;
public class Alert : IAuditableEntity
{
    public Alert() { }

    public Alert(CreateAlertCommand command) : this()
    {
        DeviceId   = command.DeviceId;
        DeviceName = command.DeviceName;
        Location   = command.Location;
        Type       = command.Type;
        Severity   = command.Severity;
        Message    = command.Message;
        Timestamp  = command.Timestamp;
        Status     = command.Status;
        Value      = command.Value;
        Threshold  = command.Threshold;
    }

    public int    Id         { get; private set; }
    
    public int    DeviceId   { get; private set; }
    public string DeviceName { get; private set; } = string.Empty;
    public string Location   { get; private set; } = string.Empty;
    public string Type       { get; private set; } = string.Empty;
    
    public string Severity   { get; private set; } = string.Empty;
    public string Message    { get; private set; } = string.Empty;
    public DateTimeOffset Timestamp { get; private set; }
    
    public string Status    { get; private set; } = string.Empty;
    public double Value     { get; private set; }
    public double Threshold { get; private set; }

    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    
    public void Resolve()
    {
        Status    = "Resuelta";
        UpdatedAt = DateTimeOffset.UtcNow;
    }
}