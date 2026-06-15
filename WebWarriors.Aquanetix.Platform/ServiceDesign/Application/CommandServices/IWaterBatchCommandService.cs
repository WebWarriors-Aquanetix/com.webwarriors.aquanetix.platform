using WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Model.Aggregates;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Model.Commands;
using WebWarriors.Aquanetix.Platform.Shared.Application.Model;

namespace WebWarriors.Aquanetix.Platform.ServiceDesign.Application.CommandServices;

public interface IWaterBatchCommandService
{
    Task<Result<WaterBatch>> Handle(CreateWaterBatchCommand command, CancellationToken cancellationToken);
    Task<Result<WaterBatch>> Handle(UpdateWaterBatchCommand command, CancellationToken cancellationToken);
}