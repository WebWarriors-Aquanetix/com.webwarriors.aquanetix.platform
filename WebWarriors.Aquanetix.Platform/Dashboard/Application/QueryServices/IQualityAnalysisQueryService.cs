using WebWarriors.Aquanetix.Platform.Dashboard.Domain.Model.Entities;
using WebWarriors.Aquanetix.Platform.Dashboard.Domain.Model.Queries;

namespace WebWarriors.Aquanetix.Platform.Dashboard.Application.QueryServices;

public interface IQualityAnalysisQueryService
{
    Task<QualityAnalysis?> Handle(GetQualityAnalysisByIdQuery query);
}