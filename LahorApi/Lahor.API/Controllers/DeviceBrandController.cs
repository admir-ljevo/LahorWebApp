using AutoMapper;
using Lahor.Core.Dto.DeviceBrand;
using Lahor.Core.SearchObjects;
using Lahor.Services.BaseService;
using Lahor.Services.DeviceBrandService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lahor.API.Controllers
{

    public class DeviceBrandController : BaseController<DeviceBrandDto, DeviceBrandUpsertDto, DeviceBrandUpsertDto, BaseSearchObject>
    {
        public DeviceBrandController(IDeviceBrandService baseService, IMapper mapper) : base(baseService, mapper)
        {
        }
    }
}
