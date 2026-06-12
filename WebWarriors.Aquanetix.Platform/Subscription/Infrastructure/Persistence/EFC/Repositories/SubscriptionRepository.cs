using WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using WebWarriors.Aquanetix.Platform.Subscription.Domain.Repositories;

namespace WebWarriors.Aquanetix.Platform.Subscription.Infrastructure.Persistence.EFC.Repositories;

public class SubscriptionRepository(
    AppDbContext context)
    : BaseRepository<
            WebWarriors.Aquanetix.Platform.Subscription.Domain.Model.Aggregates.Subscription>(context),
        ISubscriptionRepository
{
}