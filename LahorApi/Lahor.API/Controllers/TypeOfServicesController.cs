using AutoMapper;
using Lahor.Core.Dto.TypeOfService;
using Lahor.Services.TypeOfServicesService;

namespace Lahor.API.Controllers
{
    public class TypeOfServicesController : BaseController<TypeOfServiceDto, TypeOfServiceUpsertDto, TypeOfServiceUpsertDto>
    {
        public TypeOfServicesController(ITypeOfServicesService baseService, IMapper mapper) : base(baseService, mapper)
        {

        }

    }
}
