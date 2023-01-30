using Lahor.Core.Dto.New;
using Lahor.Services.BaseService;

namespace Lahor.Services.NewsService
{
    public interface INewsService : IBaseService<NewDto>, IPaginationBaseService<NewDto>
    {
        Task<List<NewDto>> GetByNameAsync(string name);
        Task<List<NewDto>> GetLastFiveNews(bool isPublic);
    }
}
