using WebWarriors.Aquanetix.Platform.Dashboard.Domain.Model.Aggregates;
using WebWarriors.Aquanetix.Platform.Dashboard.Domain.Repositories;
using WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WebWarriors.Aquanetix.Platform.Dashboard.Infrastructure.Persistence.EFC.Repositories;

public class QualityAnalysisRepository(AppDbContext context) 
    : BaseRepository<QualityAnalysis>(context), IQualityAnalysisRepository
{
}