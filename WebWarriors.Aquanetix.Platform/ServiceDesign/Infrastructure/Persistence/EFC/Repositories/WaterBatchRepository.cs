using Microsoft.EntityFrameworkCore;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Model.Aggregates;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Repositories;
using WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WebWarriors.Aquanetix.Platform.ServiceDesign.Infrastructure.Persistence.EFC.Repositories;

public class WaterBatchRepository(AppDbContext context) : BaseRepository<WaterBatch>(context), IWaterBatchRepository
{
    public async Task<IEnumerable<WaterBatch>> FindByDestinationSectorIdAsync(int sectorId, CancellationToken cancellationToken)
        => await Context.Set<WaterBatch>()
            .Where(w => w.DestinationSectorId == sectorId)
            .ToListAsync(cancellationToken);
}