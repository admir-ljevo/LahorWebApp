using AutoMapper;
using Lahor.Core.Dto.TypeOfService;
using Lahor.Core.SearchObjects;
using Lahor.Services.BaseService;
using Lahor.Services.TypeOfServicesService;
using Microsoft.AspNetCore.Mvc;

namespace Lahor.API.Controllers
{
    public class TypeOfServicesController : BaseController<TypeOfServiceDto, TypeOfServiceUpsertDto, TypeOfServiceUpsertDto, BaseSearchObject>
    {
        public TypeOfServicesController(ITypeOfServicesService baseService, IMapper mapper) : base(baseService, mapper)
        {

        }
    }
}
