using Microsoft.AspNetCore.Mvc;

namespace WebWarriors.Aquanetix.Platform.Dashboard.Interfaces.Rest;

[ApiController]
[Route("api/v1/dashboard/quality-analysis")]
public class QualityAnalysisController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(new
        {
            Id = id,
            Status = "Optimal"
        });
    }
}