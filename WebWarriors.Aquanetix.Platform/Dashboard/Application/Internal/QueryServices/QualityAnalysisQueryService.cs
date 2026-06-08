using WebWarriors.Aquanetix.Platform.Dashboard.Application.QueryServices;
using WebWarriors.Aquanetix.Platform.Dashboard.Domain.Model.Entities;
using WebWarriors.Aquanetix.Platform.Dashboard.Domain.Model.Queries;

namespace WebWarriors.Aquanetix.Platform.Dashboard.Application.Internal.QueryServices;

public class QualityAnalysisQueryService : IQualityAnalysisQueryService
{
    public async Task<QualityAnalysis?> Handle(GetQualityAnalysisByIdQuery query)
    {
        return await Task.FromResult<QualityAnalysis?>(null);
    }
}