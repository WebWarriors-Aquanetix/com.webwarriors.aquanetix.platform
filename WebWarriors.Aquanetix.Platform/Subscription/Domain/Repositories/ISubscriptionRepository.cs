using WebWarriors.Aquanetix.Platform.Subscription.Domain.Model.Aggregates;

namespace WebWarriors.Aquanetix.Platform.Subscription.Domain.Repositories;

public interface ISubscriptionRepository
{
    Task<Subscription?> FindByIdAsync(int id);
}