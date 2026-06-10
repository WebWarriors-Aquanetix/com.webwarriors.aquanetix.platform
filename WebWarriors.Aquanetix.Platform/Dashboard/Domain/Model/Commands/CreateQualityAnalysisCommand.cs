using WebWarriors.Aquanetix.Platform.Dashboard.Domain.Model.ValueObjects;

namespace WebWarriors.Aquanetix.Platform.Dashboard.Domain.Model.Commands;

public record CreateQualityAnalysisCommand(
    int Id,
    int SensorSourceId,
    AnomalyType DetectedParameters,
    AnomalyStatus AnomalyStatus,
    double SeverityScore,
    bool HasContaminationPeakPrediction,
    DateTimeOffset? CreatedAt
);