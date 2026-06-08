namespace Aquanetix.Subscriptions.Interfaces.REST.Resources;

public record SubscriptionResource(
    int Id,
    int UserId,
    string Plan,
    string Status
);