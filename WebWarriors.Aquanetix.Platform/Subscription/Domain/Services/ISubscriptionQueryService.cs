using Aquanetix.Subscriptions.Domain.Model.Aggregates;
using Aquanetix.Subscriptions.Domain.Model.Queries;

namespace Aquanetix.Subscriptions.Domain.Services;

public interface ISubscriptionQueryService
{
    Task<Subscription?> Handle(
        GetSubscriptionByIdQuery query);
}