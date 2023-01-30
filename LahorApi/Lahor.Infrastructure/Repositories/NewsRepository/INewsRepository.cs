using Lahor.Core.Dto.New;
using Lahor.Core.Entities;
using Lahor.Core.SearchObjects;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.NewsRepository
{
    public interface INewsRepository:IBaseRepository<New, int>
    {
        new Task<List<NewDto>> GetAllAsync();
        Task<List<NewDto>> GetLastFiveNews(bool isPublic);
        Task<List<NewDto>> GetByName(string name);
        Task<NewDto> GetByIdAsync(int id);
        Task<List<NewDto>> GetForPaginationAsync(BaseSearchObject searchFilter, int pageSize, int offeset)
            => throw new NotImplementedException();
    }
}
