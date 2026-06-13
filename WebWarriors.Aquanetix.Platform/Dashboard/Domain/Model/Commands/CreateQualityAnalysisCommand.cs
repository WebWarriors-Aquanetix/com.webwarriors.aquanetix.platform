using WebWarriors.Aquanetix.Platform.Dashboard.Domain.Model.ValueObjects;

namespace WebWarriors.Aquanetix.Platform.Dashboard.Domain.Model.Commands;

public record CreateQualityAnalysisCommand(
    int SensorSourceId,
    AnomalyType DetectedParameters,
    double SeverityScore
);