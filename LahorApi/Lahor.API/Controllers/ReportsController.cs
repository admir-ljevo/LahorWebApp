using AutoMapper;
using Lahor.API.Services.UserManager;
using Lahor.Core.Dto.ReportDto;
using Lahor.Services.BaseService;

namespace Lahor.API.Controllers
{
    public class ReportsController : BaseController<ReportDto, ReportDto, ReportDto>
    {
        public ReportsController(IBaseService<ReportDto> baseService, IMapper mapper) : base(baseService, mapper)
        {
        }
    }
}
