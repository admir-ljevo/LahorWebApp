using AutoMapper;
using Lahor.Core.Dto.New;
using Lahor.Services.NewsService;

namespace Lahor.API.Controllers
{
    public class NewsController : BaseController<NewDto, NewInsertDto, NewUpdateDto>
    {
        public NewsController(INewsService baseService, IMapper mapper) : base(baseService, mapper)
        {

        }

    }
}
