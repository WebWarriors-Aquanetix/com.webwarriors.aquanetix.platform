using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using WebWarriors.Aquanetix.Platform.Monitoring.Domain.Model;
using WebWarriors.Aquanetix.Platform.Monitoring.Domain.Model.Aggregates;
using WebWarriors.Aquanetix.Platform.Shared.Application.Model;
using WebWarriors.Aquanetix.Platform.Shared.Interfaces.Rest.ProblemDetails;
using WebWarriors.Aquanetix.Platform.Shared.Resources.Errors;

namespace WebWarriors.Aquanetix.Platform.Monitoring.Interfaces.Rest.Transform;

public static class MonitoringActionResultAssembler
{
    private static int ToStatusCode(MonitoringError error) => error switch
    {
        MonitoringError.AlertNotFound        => StatusCodes.Status404NotFound,
        MonitoringError.AlertAlreadyResolved => StatusCodes.Status409Conflict,
        MonitoringError.InvalidSeverityLevel => StatusCodes.Status400BadRequest,
        MonitoringError.DeviceNotLinked      => StatusCodes.Status400BadRequest,
        MonitoringError.OperationCancelled   => StatusCodes.Status409Conflict,
        MonitoringError.DatabaseError        => StatusCodes.Status500InternalServerError,
        MonitoringError.InternalServerError  => StatusCodes.Status500InternalServerError,
        _                                    => StatusCodes.Status400BadRequest
    };

    public static IActionResult ToActionResultFromCreateAlertResult(
        ControllerBase controller,
        Result<Alert> result,
        IStringLocalizer<ErrorMessages> errorLocalizer,
        ProblemDetailsFactory problemDetailsFactory,
        Func<Alert, IActionResult> successAction)
    {
        if (result.IsSuccess) return successAction(result.Value!);
        var statusCode = ToStatusCode((MonitoringError)result.Error!);
        return problemDetailsFactory.CreateProblemDetails(controller, statusCode, result.Error, result.Message);
    }

    public static IActionResult ToActionResultFromUpdateAlertResult(
        ControllerBase controller,
        Result<Alert> result,
        IStringLocalizer<ErrorMessages> errorLocalizer,
        ProblemDetailsFactory problemDetailsFactory,
        Func<Alert, IActionResult> successAction)
    {
        if (result.IsSuccess) return successAction(result.Value!);
        var statusCode = ToStatusCode((MonitoringError)result.Error!);
        return problemDetailsFactory.CreateProblemDetails(controller, statusCode, result.Error, result.Message);
    }

    public static IActionResult ToActionResultFromGetAlertByIdResult(
        ControllerBase controller,
        Alert? alert,
        IStringLocalizer<ErrorMessages> errorLocalizer,
        ProblemDetailsFactory problemDetailsFactory,
        Func<Alert, IActionResult> successAction)
    {
        if (alert is null)
            return problemDetailsFactory.CreateProblemDetails(
                controller,
                ToStatusCode(MonitoringError.AlertNotFound),
                MonitoringError.AlertNotFound,
                errorLocalizer[nameof(MonitoringError.AlertNotFound)]);
        return successAction(alert);
    }
}