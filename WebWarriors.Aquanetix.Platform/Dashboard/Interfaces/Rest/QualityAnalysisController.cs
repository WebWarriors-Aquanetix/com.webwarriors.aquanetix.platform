using Microsoft.AspNetCore.Mvc;
using WebWarriors.Aquanetix.Platform.Dashboard.Application.QueryServices;
using WebWarriors.Aquanetix.Platform.Dashboard.Domain.Model.Queries;
using WebWarriors.Aquanetix.Platform.Dashboard.Interfaces.Rest.Resources;
using WebWarriors.Aquanetix.Platform.Dashboard.Interfaces.Rest.Transform;

namespace WebWarriors.Aquanetix.Platform.Dashboard.Interfaces.Rest;

[ApiController]
[Route("api/v1/[controller]")]
public class QualityAnalysisController(IQualityAnalysisQueryService qualityAnalysisQueryService)
    : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<QualityAnalysisResource>> GetQualityAnalysisById(
        int id, CancellationToken cancellationToken)
    {
        var query = new GetQualityAnalysisByIdQuery(id);
        var result = await qualityAnalysisQueryService.Handle(query, cancellationToken);

        if (result is null)
            return NotFound();

        return Ok(QualityAnalysisResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<QualityAnalysisResource>>> GetAllQualityAnalyses(
        CancellationToken cancellationToken)
    {
        var query = new GetAllQualityAnalysesQuery();
        var result = await qualityAnalysisQueryService.Handle(query, cancellationToken);

        return Ok(result.Select(QualityAnalysisResourceFromEntityAssembler.ToResourceFromEntity));
    }
}