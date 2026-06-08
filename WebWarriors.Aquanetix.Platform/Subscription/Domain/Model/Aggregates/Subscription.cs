namespace WebWarriors.Aquanetix.Platform.Subscription.Domain.Model.Aggregates;

public class Subscription
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Plan { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;
}