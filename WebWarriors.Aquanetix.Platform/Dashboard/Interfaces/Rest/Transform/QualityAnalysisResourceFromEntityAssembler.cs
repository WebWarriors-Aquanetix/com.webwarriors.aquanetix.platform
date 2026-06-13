using WebWarriors.Aquanetix.Platform.Dashboard.Domain.Model.Aggregates;
using WebWarriors.Aquanetix.Platform.Dashboard.Interfaces.Rest.Resources;

namespace WebWarriors.Aquanetix.Platform.Dashboard.Interfaces.Rest.Transform;

public static class QualityAnalysisResourceFromEntityAssembler
{
    public static QualityAnalysisResource ToResourceFromEntity(QualityAnalysis entity)
        => new(
            entity.Id,
            entity.SensorSourceId,
            entity.DetectedParameters.ToString(),
            entity.AnomalyStatus.ToString(),
            entity.SeverityScore,
            entity.HasContaminationPeakPrediction,
            entity.CreatedAt,
            entity.UpdatedAt
        );
}