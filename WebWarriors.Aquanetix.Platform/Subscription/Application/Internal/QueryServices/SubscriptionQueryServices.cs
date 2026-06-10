using WebWarriors.Aquanetix.Platform.Subscription.Domain.Model.Queries;
using WebWarriors.Aquanetix.Platform.Subscription.Domain.Services;

using SubscriptionEntity =
    WebWarriors.Aquanetix.Platform.Subscription.Domain.Model.Aggregates.Subscription;

namespace WebWarriors.Aquanetix.Platform.Subscription.Application.Internal.QueryServices;

public class SubscriptionQueryService : ISubscriptionQueryService
{
    public Task<SubscriptionEntity?> Handle(
        GetSubscriptionByIdQuery query)
    {
        var subscription = new SubscriptionEntity(
            1,
            "Premium",
            "Active"
        );

        return Task.FromResult<SubscriptionEntity?>(subscription);
    }
}