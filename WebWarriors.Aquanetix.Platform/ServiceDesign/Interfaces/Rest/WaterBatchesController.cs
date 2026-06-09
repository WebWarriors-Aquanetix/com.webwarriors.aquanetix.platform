using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Swashbuckle.AspNetCore.Annotations;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Application.CommandServices;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Application.QueryServices;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Model.Queries;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Interfaces.Rest.Resources;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Interfaces.Rest.Transform;
using WebWarriors.Aquanetix.Platform.Shared.Interfaces.Rest.ProblemDetails;
using WebWarriors.Aquanetix.Platform.Shared.Resources.Errors;

namespace WebWarriors.Aquanetix.Platform.ServiceDesign.Interfaces.Rest;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Water Batch endpoints")]
public class WaterBatchesController(
    IWaterBatchQueryService waterBatchQueryService,
    IWaterBatchCommandService waterBatchCommandService,
    IStringLocalizer<ErrorMessages> errorLocalizer,
    ProblemDetailsFactory problemDetailsFactory)
    : ControllerBase
{
    [HttpGet]
    [SwaggerOperation(Summary = "Get all water batches", OperationId = "GetAllWaterBatches")]
    [SwaggerResponse(StatusCodes.Status200OK, "Water batches retrieved", typeof(IEnumerable<WaterBatchResource>))]
    public async Task<IActionResult> GetAllWaterBatches(CancellationToken cancellationToken)
    {
        var batches = await waterBatchQueryService.Handle(new GetAllWaterBatchesQuery(), cancellationToken);
        return Ok(batches.Select(WaterBatchResourceFromEntityAssembler.ToResourceFromEntity));
    }

    [HttpGet("{waterBatchId:int}")]
    [SwaggerOperation(Summary = "Get water batch by id", OperationId = "GetWaterBatchById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Water batch found", typeof(WaterBatchResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Water batch not found")]
    public async Task<IActionResult> GetWaterBatchById([FromRoute] int waterBatchId, CancellationToken cancellationToken)
    {
        var batch = await waterBatchQueryService.Handle(new GetWaterBatchByIdQuery(waterBatchId), cancellationToken);
        if (batch is null)
            return problemDetailsFactory.CreateProblemDetails(
                this,
                StatusCodes.Status404NotFound,
                "WaterBatchNotFound",
                errorLocalizer["ServiceDesignError.WaterBatchNotFound"]);
        return Ok(WaterBatchResourceFromEntityAssembler.ToResourceFromEntity(batch));
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create a water batch", OperationId = "CreateWaterBatch")]
    [SwaggerResponse(StatusCodes.Status201Created, "Water batch created", typeof(WaterBatchResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request")]
    public async Task<IActionResult> CreateWaterBatch([FromBody] CreateWaterBatchResource resource,
        CancellationToken cancellationToken)
    {
        var command = CreateWaterBatchCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result  = await waterBatchCommandService.Handle(command, cancellationToken);
        if (!result.IsSuccess)
            return problemDetailsFactory.CreateProblemDetails(
                this,
                StatusCodes.Status400BadRequest,
                result.Error,
                result.Message);
        return CreatedAtAction(nameof(GetWaterBatchById),
            new { waterBatchId = result.Value!.Id },
            WaterBatchResourceFromEntityAssembler.ToResourceFromEntity(result.Value));
    }
}
