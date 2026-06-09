using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WebWarriors.Aquanetix.Platform.Devices.Application.QueryServices;
using WebWarriors.Aquanetix.Platform.Devices.Domain.Model.Queries;
using WebWarriors.Aquanetix.Platform.Devices.Interfaces.REST.Resources;
using WebWarriors.Aquanetix.Platform.Devices.Interfaces.REST.Transform;

namespace WebWarriors.Aquanetix.Platform.Devices.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Devices")]
public class DevicesController(IDeviceQueryService deviceQueryService) : ControllerBase
{
    /// <summary>
    /// Get a device by its unique identifier.
    /// </summary>
    /// <param name="deviceId">The ID of the device.</param>
    /// <returns>The device resource matching the ID.</returns>
    [HttpGet("{deviceId:int}")]
    public async Task<IActionResult> GetDeviceById(int deviceId)
    {
        // 1. Creamos el objeto Query con el ID recibido en la URL
        var getDeviceByIdQuery = new GetDeviceByIdQuery(deviceId);
        
        // 2. Ejecutamos la consulta en la capa de aplicación pasando el RequestAborted como token
        var device = await deviceQueryService.Handle(getDeviceByIdQuery, HttpContext.RequestAborted);

        // 3. Si la base de datos devuelve null, respondemos con un 404 Not Found
        if (device is null) return NotFound();

        // 4. Si existe, lo transformamos a nuestro DTO (Resource) y respondemos 200 OK
        var deviceResource = DeviceResourceFromEntityAssembler.ToResourceFromEntity(device);
        return Ok(deviceResource);
    }
}