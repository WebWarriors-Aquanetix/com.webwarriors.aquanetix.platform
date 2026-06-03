using WebWarriors.Aquanetix.Platform.Dashboard.Domain.Model.ValueObjects;

namespace WebWarriors.Aquanetix.Platform.Dashboard.Domain.Model.Entities;

public class Alert
{
    public int Id { get; private set; }
    public int AnalysisId { get; private set; }
    public AnomalyType AnomalyType { get; private set; }
    public double SeverityScore { get; private set; }
    public DateTimeOffset GeneratedAt { get; private set; }
    public DateTimeOffset? SentAt { get; private set; }

    public Alert(int analysisId, AnomalyType anomalyType, double severityScore)
    {
        AnalysisId = analysisId;
        AnomalyType = anomalyType;
        SeverityScore = severityScore;
        GeneratedAt = DateTimeOffset.UtcNow;
    }

    public void MarkAsSent()
    {
        SentAt = DateTimeOffset.UtcNow;
    }
}