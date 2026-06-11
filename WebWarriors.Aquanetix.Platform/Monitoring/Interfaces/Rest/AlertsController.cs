using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Swashbuckle.AspNetCore.Annotations;
using WebWarriors.Aquanetix.Platform.Monitoring.Application.CommandServices;
using WebWarriors.Aquanetix.Platform.Monitoring.Application.QueryServices;
using WebWarriors.Aquanetix.Platform.Monitoring.Domain.Model.Queries;
using WebWarriors.Aquanetix.Platform.Monitoring.Interfaces.Rest.Resources;
using WebWarriors.Aquanetix.Platform.Monitoring.Interfaces.Rest.Transform;
using WebWarriors.Aquanetix.Platform.Shared.Interfaces.Rest.ProblemDetails;
using WebWarriors.Aquanetix.Platform.Shared.Resources.Errors;

namespace WebWarriors.Aquanetix.Platform.Monitoring.Interfaces.Rest;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Alert endpoints")]
public class AlertsController(
    IAlertQueryService alertQueryService,
    IAlertCommandService alertCommandService,
    IStringLocalizer<ErrorMessages> errorLocalizer,
    ProblemDetailsFactory problemDetailsFactory)
    : ControllerBase
{
    private readonly IStringLocalizer<ErrorMessages> _errorLocalizer = errorLocalizer;
    private readonly ProblemDetailsFactory _problemDetailsFactory = problemDetailsFactory;

  

    [HttpGet("{alertId:int}")]
    [SwaggerOperation(Summary = "Get alert by id", OperationId = "GetAlertById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Alert found", typeof(AlertResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Alert not found")]
    public async Task<IActionResult> GetAlertById([FromRoute] int alertId, CancellationToken cancellationToken)
    {
        var alert = await alertQueryService.Handle(new GetAlertByIdQuery(alertId), cancellationToken);
        return MonitoringActionResultAssembler.ToActionResultFromGetAlertByIdResult(
            this, alert, _errorLocalizer, _problemDetailsFactory,
            found => Ok(AlertResourceFromEntityAssembler.ToResourceFromEntity(found)));
    }

  
}