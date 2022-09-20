using AutoMapper;
using Lahor.Core.Dto.Service;
using Lahor.Core.SearchObjects;
using Lahor.Services.ServicesService;
using Microsoft.AspNetCore.Mvc;

namespace Lahor.API.Controllers
{
    public class ServicesController : BaseController<ServiceDto, ServiceUpsertDto, ServiceUpsertDto,BaseSearchObject>
    {
        private readonly IServicesService ServicesService;
        public ServicesController(IServicesService baseService, IMapper mapper) : base(baseService, mapper)
        {
            ServicesService = baseService;
        }

        [HttpGet("PriceList")]
        public async Task<IActionResult> GetPriceList()
        {
            return Ok(await ServicesService.GetPriceList());
        }

    }
}
