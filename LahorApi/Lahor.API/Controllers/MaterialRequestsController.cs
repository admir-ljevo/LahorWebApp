using AutoMapper;
using Lahor.Core.Dto.MaterialRequests;
using Lahor.Core.SearchObjects;
using Lahor.Services.BaseService;
using Lahor.Services.MaterialRequestsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lahor.API.Controllers
{
    public class MaterialRequestsController : BaseController<MaterialRequestsDto, MaterialRequestsUpsertDto, MaterialRequestsUpsertDto, BaseSearchObject>
    {
        private readonly IMaterialRequestsService MaterialRequestsService;

        public MaterialRequestsController(IMaterialRequestsService baseService, IMapper mapper) : base(baseService, mapper)
        {
            MaterialRequestsService = baseService;
        }

        [HttpGet("requestId/{requestId:int}")]
        public async Task<IActionResult> GetByRequestId(int requestId)
        {
            return Ok(await MaterialRequestsService.GetByRequestId(requestId));
        }

    }
}
