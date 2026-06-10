using WebWarriors.Aquanetix.Platform.Subscription.Domain.Model.Queries;

namespace WebWarriors.Aquanetix.Platform.Subscription.Domain.Services;

public interface ISubscriptionQueryService
{
    Task<WebWarriors.Aquanetix.Platform.Subscription.Domain.Model.Aggregates.Subscription?>
        Handle(GetSubscriptionByIdQuery query);
}