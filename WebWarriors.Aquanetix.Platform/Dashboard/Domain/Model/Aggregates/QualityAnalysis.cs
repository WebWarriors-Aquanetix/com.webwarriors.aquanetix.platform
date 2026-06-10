using WebWarriors.Aquanetix.Platform.Dashboard.Domain.Model.ValueObjects;

using WebWarriors.Aquanetix.Platform.Shared.Domain.Model.Entities;

namespace WebWarriors.Aquanetix.Platform.Dashboard.Domain.Model.Aggregates;

public class QualityAnalysis : IAuditableEntity
{
    public int Id { get; private set; }
    public int SensorSourceId { get; private set; }
    public AnomalyType DetectedParameters { get; private set; }
    public AnomalyStatus AnomalyStatus { get; private set; }
    public double SeverityScore { get; private set; }
    public bool HasContaminationPeakPrediction { get; private set; }

    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    public QualityAnalysis(int sensorSourceId, AnomalyType detectedParameters,
        double severityScore)
    {
        SensorSourceId = sensorSourceId;
        DetectedParameters = detectedParameters;
        SeverityScore = severityScore;
        AnomalyStatus = AnomalyStatus.Detected;
        HasContaminationPeakPrediction = false;
    }

    public void EvaluateAnomaly()
    {
        AnomalyStatus = AnomalyStatus.Evaluated;
    }

    public void ConfirmAnomaly()
    {
        AnomalyStatus = AnomalyStatus.Confirmed;
    }

    public void DismissAnomaly()
    {
        AnomalyStatus = AnomalyStatus.Dismissed;
    }

    public void MarkContaminationPeakPrediction()
    {
        HasContaminationPeakPrediction = true;
    }
}