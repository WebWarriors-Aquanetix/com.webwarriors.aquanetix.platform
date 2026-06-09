using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Application.CommandServices;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Model;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Model.Aggregates;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Model.Commands;
using WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Repositories;
using WebWarriors.Aquanetix.Platform.Shared.Application.Model;
using WebWarriors.Aquanetix.Platform.Shared.Domain.Repositories;
using WebWarriors.Aquanetix.Platform.Shared.Resources.Errors;

namespace WebWarriors.Aquanetix.Platform.ServiceDesign.Application.Internal.CommandServices;

public class WaterBatchCommandService(
    IWaterBatchRepository waterBatchRepository,
    IUnitOfWork unitOfWork,
    IStringLocalizer<ErrorMessages> localizer)
    : IWaterBatchCommandService
{
    /// <inheritdoc />
    public async Task<Result<WaterBatch>> Handle(CreateWaterBatchCommand command, CancellationToken cancellationToken)
    {
        var waterBatch = new WaterBatch(command);
        try
        {
            await waterBatchRepository.AddAsync(waterBatch, cancellationToken);
            await unitOfWork.CompleteAsync(cancellationToken);
            return Result<WaterBatch>.Success(waterBatch);
        }
        catch (OperationCanceledException)
        {
            return Result<WaterBatch>.Failure(ServiceDesignError.OperationCancelled,
                localizer[nameof(ServiceDesignError.OperationCancelled)]);
        }
        catch (DbUpdateException)
        {
            return Result<WaterBatch>.Failure(ServiceDesignError.DatabaseError,
                localizer[nameof(ServiceDesignError.DatabaseError)]);
        }
        catch (Exception)
        {
            return Result<WaterBatch>.Failure(ServiceDesignError.InternalServerError,
                localizer[nameof(ServiceDesignError.InternalServerError)]);
        }
    }
}
