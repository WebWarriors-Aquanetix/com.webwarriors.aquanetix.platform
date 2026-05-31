namespace WebWarriors.Aquanetix.Platform.Monitoring.Domain.Model.Entities;

public class MaintenanceFinding
{
    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public bool RequiresFollowUp { get; private set; }

    public MaintenanceFinding(string description, bool requiresFollowUp)
    {
        Id = Guid.NewGuid();
        Description = description;
        RequiresFollowUp = requiresFollowUp;
    }
}