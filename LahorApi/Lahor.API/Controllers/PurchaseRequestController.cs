using AutoMapper;
using Lahor.Core.Dto.PurchaseRequest;
using Lahor.Core.SearchObjects;
using Lahor.Services.BaseService;
using Lahor.Services.PurchaseRequestService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lahor.API.Controllers
{

    public class PurchaseRequestController : BaseController<PurchaseRequestDto, PurchaseRequestUpsertDto, PurchaseRequestUpsertDto, BaseSearchObject>
    {

        public PurchaseRequestController(IPurchaseRequestService baseService, IMapper mapper) : base(baseService, mapper)
        {
        }
    }
}
