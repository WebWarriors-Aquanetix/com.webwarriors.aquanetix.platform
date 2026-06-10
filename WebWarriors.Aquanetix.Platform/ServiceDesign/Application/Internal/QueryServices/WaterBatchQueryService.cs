using WebWarriors.Aquanetix.Platform.ServiceDesign.Application.QueryServices;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Model.Aggregates;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Model.Queries;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Repositories;

namespace WebWarriors.Aquanetix.Platform.ServiceDesign.Application.Internal.QueryServices;

public class WaterBatchQueryService(IWaterBatchRepository waterBatchRepository) : IWaterBatchQueryService
{
    public async Task<IEnumerable<WaterBatch>> Handle(GetAllWaterBatchesQuery query, CancellationToken cancellationToken)
        => await waterBatchRepository.ListAsync(cancellationToken);
}