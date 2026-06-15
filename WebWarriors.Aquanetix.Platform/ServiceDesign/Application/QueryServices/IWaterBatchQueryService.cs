using WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Model.Aggregates;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Model.Queries;

namespace WebWarriors.Aquanetix.Platform.ServiceDesign.Application.QueryServices;

public interface IWaterBatchQueryService
{
    Task<IEnumerable<WaterBatch>> Handle(GetAllWaterBatchesQuery query, CancellationToken cancellationToken);
    Task<WaterBatch?> Handle(GetWaterBatchByIdQuery query, CancellationToken cancellationToken);
}