using WebWarriors.Aquanetix.Platform.Shared.Domain.Model;

namespace WebWarriors.Aquanetix.Platform.Monitoring.Domain.Model.Errors;

public static class MonitoringErrors
{
    public static readonly Error AlertNotFound =
        new("Monitoring.AlertNotFound", "The specified alert was not found.");

    public static readonly Error AlertAlreadyResolved =
        new("Monitoring.AlertAlreadyResolved", "The specified alert has already been resolved.");

    public static readonly Error InvalidSeverityLevel =
        new("Monitoring.InvalidSeverityLevel", "The severity level provided is invalid.");

    public static readonly Error DeviceNotLinked =
        new("Monitoring.DeviceNotLinked", "No device is linked to this alert.");
}