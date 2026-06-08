using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Localization;
using WebWarriors.Aquanetix.Platform.Devices.Application.CommandServices;
using WebWarriors.Aquanetix.Platform.Devices.Domain.Model;
using WebWarriors.Aquanetix.Platform.Devices.Domain.Model.Aggregates;
using WebWarriors.Aquanetix.Platform.Devices.Domain.Model.Command;
using WebWarriors.Aquanetix.Platform.Devices.Domain.Model.ValueObjects;
using WebWarriors.Aquanetix.Platform.Devices.Domain.Repositories;
using WebWarriors.Aquanetix.Platform.Shared.Application.Model;
using WebWarriors.Aquanetix.Platform.Shared.Domain.Repositories;
using WebWarriors.Aquanetix.Platform.Shared.Resources.Errors;

namespace WebWarriors.Aquanetix.Platform.Devices.Application.Internal.CommandServices;

public class DeviceCommandService
{
    private readonly IDeviceRepository _deviceRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStringLocalizer<ErrorMessages> _localizer;

    public DeviceCommandService(
        IDeviceRepository deviceRepository, 
        IUnitOfWork unitOfWork, 
        IStringLocalizer<ErrorMessages> localizer)
    {
        _deviceRepository = deviceRepository;
        _unitOfWork = unitOfWork;
        _localizer = localizer;
    }
}