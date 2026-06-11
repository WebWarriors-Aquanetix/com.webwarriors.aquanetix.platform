using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Application.QueryServices;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Model.Queries;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Interfaces.Rest.Resources;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Interfaces.Rest.Transform;

namespace WebWarriors.Aquanetix.Platform.ServiceDesign.Interfaces.Rest;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Water Batch endpoints")]
public class WaterBatchesController(IWaterBatchQueryService waterBatchQueryService) : ControllerBase
{
    [HttpGet]
    [SwaggerOperation(Summary = "Get all water batches", OperationId = "GetAllWaterBatches")]
    [SwaggerResponse(StatusCodes.Status200OK, "Water batches retrieved", typeof(IEnumerable<WaterBatchResource>))]
    public async Task<IActionResult> GetAllWaterBatches(CancellationToken cancellationToken)
    {
        var batches = await waterBatchQueryService.Handle(new GetAllWaterBatchesQuery(), cancellationToken);
        return Ok(batches.Select(WaterBatchResourceFromEntityAssembler.ToResourceFromEntity));
    }
}