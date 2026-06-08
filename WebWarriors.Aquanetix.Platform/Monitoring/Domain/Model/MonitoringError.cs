namespace WebWarriors.Aquanetix.Platform.Monitoring.Domain.Model;

public enum MonitoringError
{
    None,
    AlertNotFound,
    AlertAlreadyResolved,
    InvalidSeverityLevel,
    DeviceNotLinked,
    OperationCancelled,
    DatabaseError,
    InternalServerError
}