using AutoMapper;
using Lahor.Core.Dto.Service;
using Lahor.Services.ServicesService;

namespace Lahor.API.Controllers
{
    public class ServicesController : BaseController<ServiceDto, ServiceUpsertDto, ServiceUpsertDto>
    {
        public ServicesController(IServicesService baseService, IMapper mapper) : base(baseService, mapper)
        {

        }

    }
}
