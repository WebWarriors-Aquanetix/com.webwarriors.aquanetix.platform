using WebWarriors.Aquanetix.Platform.Subscription.Domain.Model.Aggregates;
using WebWarriors.Aquanetix.Platform.Subscription.Domain.Repositories;

namespace WebWarriors.Aquanetix.Platform.Subscription.Infrastructure.Persistence.EFC.Repositories;

public class SubscriptionRepository : ISubscriptionRepository
{
    public async Task<Subscription?> FindByIdAsync(int id)
    {
        return await Task.FromResult(
            new Subscription
            {
                Id = id,
                UserId = 1,
                Plan = "Basic",
                Status = "Active"
            });
    }
}