namespace WebWarriors.Aquanetix.Platform.Dashboard.Interfaces.Rest.Resources;

public record QualityAnalysisResource(
    int Id,
    int SensorSourceId,
    string DetectedParameters,
    string AnomalyStatus,
    double SeverityScore,
    bool HasContaminationPeakPrediction,
    DateTimeOffset? CreatedAt,
    DateTimeOffset? UpdatedAt 
);