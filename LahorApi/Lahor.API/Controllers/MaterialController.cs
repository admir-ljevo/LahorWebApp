using AutoMapper;
using Lahor.Core.Dto.Material;
using Lahor.Core.SearchObjects;
using Lahor.Services.BaseService;
using Lahor.Services.MaterialService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lahor.API.Controllers
{

    public class MaterialController : BaseController<MaterialDto, MaterialUpsertDto, MaterialUpsertDto, BaseSearchObject>
    {
        private readonly IMaterialService materialService;

        public MaterialController(IMaterialService baseService, IMapper mapper) : base(baseService, mapper)
        {
            materialService = baseService;
        }
        [HttpGet("sortCol/{sortCol}/sortDir/{sortDir}/nameFilter/{nameFilter?}")]
        public async Task<IActionResult> GetAllOrdered(string sortCol, string sortDir, string? nameFilter = null)
        {
            return Ok(await materialService.GetAllOrdered(sortCol, sortDir, nameFilter));
        }
    }
}
