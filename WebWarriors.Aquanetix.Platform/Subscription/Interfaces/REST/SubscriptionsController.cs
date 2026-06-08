using Microsoft.AspNetCore.Mvc;
using Aquanetix.Subscriptions.Domain.Model.Queries;
using Aquanetix.Subscriptions.Domain.Services;
using Aquanetix.Subscriptions.Interfaces.REST.Transform;

namespace Aquanetix.Subscriptions.Interfaces.REST;

[ApiController]
[Route("api/v1/subscriptions")]
public class SubscriptionsController : ControllerBase
{
    private readonly ISubscriptionQueryService queryService;

    public SubscriptionsController(
        ISubscriptionQueryService queryService)
    {
        this.queryService = queryService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query =
            new GetSubscriptionByIdQuery(id);

        var subscription =
            await queryService.Handle(query);

        if (subscription is null)
            return NotFound();

        var resource =
            SubscriptionResourceFromEntityAssembler
                .ToResource(subscription);

        return Ok(resource);
    }
}