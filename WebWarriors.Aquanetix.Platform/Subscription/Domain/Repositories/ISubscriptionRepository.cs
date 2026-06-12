using WebWarriors.Aquanetix.Platform.Shared.Domain.Repositories;

namespace WebWarriors.Aquanetix.Platform.Subscription.Domain.Repositories;

public interface ISubscriptionRepository :
    IBaseRepository<
        WebWarriors.Aquanetix.Platform.Subscription.Domain.Model.Aggregates.Subscription>
{
}