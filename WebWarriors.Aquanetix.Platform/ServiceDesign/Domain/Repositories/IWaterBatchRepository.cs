using WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Model.Aggregates;
using WebWarriors.Aquanetix.Platform.Shared.Domain.Repositories;

namespace WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Repositories;

public interface IWaterBatchRepository : IBaseRepository<WaterBatch>
{
    Task<IEnumerable<WaterBatch>> FindByDestinationSectorIdAsync(int sectorId, CancellationToken cancellationToken);
}