using Aquanetix.Subscriptions.Domain.Model.Aggregates;
using Aquanetix.Subscriptions.Interfaces.REST.Resources;

namespace Aquanetix.Subscriptions.Interfaces.REST.Transform;

public static class SubscriptionResourceFromEntityAssembler
{
    public static SubscriptionResource ToResource(
        Subscription entity)
    {
        return new SubscriptionResource(
            entity.Id,
            entity.UserId,
            entity.Plan.ToString(),
            entity.Status.ToString()
        );
    }
}