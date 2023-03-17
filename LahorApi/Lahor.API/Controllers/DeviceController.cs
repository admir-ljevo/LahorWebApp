using AutoMapper;
using Lahor.Core.Dto.Device;
using Lahor.Core.SearchObjects;
using Lahor.Services.DeviceService;
using Lahor.Services.OrdersServicesLevelsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lahor.API.Controllers
{
 
    public class DeviceController : BaseController<DeviceDto, DeviceUpsertDto, DeviceUpsertDto, BaseSearchObject>
    {
        private readonly IDeviceService DeviceService;
        public DeviceController(IDeviceService baseService, IMapper mapper): base(baseService, mapper)
        {
            DeviceService = baseService;
        }
        [HttpGet("sortCol/{sortCol}/sortDir/{sortDir}")]
        public async Task<IActionResult> GetAllOrderedAsync(string sortCol, string sortDir)
        {
            return Ok(await DeviceService.GetAllOrderedAsync(sortCol, sortDir)); 
        }

    }
}
