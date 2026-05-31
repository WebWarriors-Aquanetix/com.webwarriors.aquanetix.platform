namespace WebWarriors.Aquanetix.Platform.Monitoring.Domain.Model.Aggregates;

using Entities;
using ValueObjects;

public class WorkOrder
{
    public Guid WorkOrderId { get; private set; }
    public Guid? AssignedTechnicianId { get; private set; } // Opcional hasta que se asigne
    public DateTimeOffset ScheduledDate { get; private set; }
    public WorkOrderStatus Status { get; private set; }
    public ResolutionDetails? Resolution { get; private set; }

    private readonly List<MaintenanceFinding> _findings;
    public IReadOnlyCollection<MaintenanceFinding> Findings => _findings.AsReadOnly();

   
    public WorkOrder(DateTimeOffset scheduledDate)
    {
        WorkOrderId = Guid.NewGuid();
        ScheduledDate = scheduledDate;
        Status = WorkOrderStatus.Generated;
        _findings = new List<MaintenanceFinding>();
    }


    public void AssignTechnician(Guid technicianId)
    {
        if (Status == WorkOrderStatus.Finalized)
            throw new InvalidOperationException("Cannot assign a technician to a finalized work order.");

        AssignedTechnicianId = technicianId;
        Status = WorkOrderStatus.Assigned;
    }

 
    public void StartMaintenance()
    {
        if (AssignedTechnicianId == null)
            throw new InvalidOperationException("Must assign a technician before starting.");

        Status = WorkOrderStatus.InProgress;
    }


    public void AddFinding(MaintenanceFinding finding)
    {
        _findings.Add(finding);
    }


    public void FinalizeWorkOrder(ResolutionDetails resolutionDetails)
    {
        if (Status != WorkOrderStatus.InProgress)
            throw new InvalidOperationException("Work order must be in progress to be finalized.");

        Resolution = resolutionDetails;
        Status = WorkOrderStatus.Finalized;
    }
}