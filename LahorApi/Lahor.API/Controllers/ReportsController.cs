using AutoMapper;
using Lahor.Core.Dto.ReportDto;
using Lahor.Core.SearchObjects;
using Lahor.Services.BaseService;

namespace Lahor.API.Controllers
{
    public class ReportsController : BaseController<ReportDto, ReportDto, ReportDto,BaseSearchObject>
    {
        public ReportsController(IBaseService<ReportDto> baseService, IMapper mapper) : base(baseService, mapper)
        {
        }
    }
}
