using AutoMapper;
using Lahor.Core.Dto.LevelOfServiceExecution;
using Lahor.Core.SearchObjects;
using Lahor.Services.LevelOfServiceExecutionsService;

namespace Lahor.API.Controllers
{
 
    public class LevelOfServiceExecutionController : BaseController<LevelOfServiceExecutionDto, LevelOfServiceExecutionDto, LevelOfServiceExecutionDto, BaseSearchObject>
    {
        public LevelOfServiceExecutionController(ILevelOfServiceExecutionsService baseService, IMapper mapper) : base(baseService, mapper)
        {

        }
    }
}
