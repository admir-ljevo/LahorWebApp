using AutoMapper;
using Lahor.Core.Dto.DeviceType;
using Lahor.Core.SearchObjects;
using Lahor.Services.BaseService;
using Lahor.Services.DeviceTypeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lahor.API.Controllers
{
    public class DeviceTypeController : BaseController<DeviceTypeDto, DeviceTypeUpsertDto, DeviceTypeUpsertDto, BaseSearchObject>
    {
        public DeviceTypeController(IDeviceTypeService baseService, IMapper mapper) : base(baseService, mapper)
        {
        }
    }
}
