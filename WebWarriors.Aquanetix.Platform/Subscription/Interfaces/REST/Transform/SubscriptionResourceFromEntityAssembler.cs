using WebWarriors.Aquanetix.Platform.Subscription.Interfaces.REST.Resources;

namespace WebWarriors.Aquanetix.Platform.Subscription.Interfaces.REST.Transform;

public static class SubscriptionResourceFromEntityAssembler
{
    public static SubscriptionResource ToResource(
        WebWarriors.Aquanetix.Platform.Subscription.Domain.Model.Aggregates.Subscription entity)
    {
        return new SubscriptionResource(
            entity.Id,
            entity.UserId,
            entity.Plan,
            entity.Status
        );
    }
}