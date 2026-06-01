using WebWarriors.Aquanetix.Platform.Shared.Domain.Model.Entities;

namespace WebWarriors.Aquanetix.Platform.Shared.Domain.Model.Aggregates;

public class Analysis : IAuditableEntity
{
    public int Id { get; private set; }
    public string SensorSourceId { get; private set; }
    public string DetectedParameters { get; private set; }
    public string AnomalyStatus { get; private set; }
    public int SeverityScore { get; private set; }
    
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    public Analysis(string sensorSourceId, string detectedParameters, 
        string anomalyStatus, int severityScore)
    {
        SensorSourceId = sensorSourceId;
        DetectedParameters = detectedParameters;
        AnomalyStatus = anomalyStatus;
        SeverityScore = severityScore;
    }
}