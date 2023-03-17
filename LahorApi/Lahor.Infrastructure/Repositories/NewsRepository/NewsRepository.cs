using AutoMapper;
using Lahor.Core.Dto.New;
using Lahor.Core.Dto;
using Lahor.Core.Entities;
using Lahor.Core.SearchObjects;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.NewsRepository
{
    public class NewsRepository : BaseRepository<New, int>, INewsRepository
    {
        public NewsRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }

        public async Task<NewDto> GetByIdAsync(int id)
        {

            var news = await ProjectToFirstOrDefaultAsync<NewDto>(DatabaseContext.News.Where(n => n.Id == id));
            news.User.Person= await ProjectToFirstOrDefaultAsync<PersonDto>(DatabaseContext.Persons.Where(n => n.ApplicationUserId == news.UserId));
            return news;
        }

        public Task<List<NewDto>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async new Task<List<NewDto>> GetAllAsync()
        {
            return await ProjectToListAsync<NewDto>(DatabaseContext.News.Where(x=>x.IsDeleted==false));
        }

        public async Task<List<NewDto>> GetLastFiveNews(bool isPublic)
        {
            return await ProjectToListAsync<NewDto>(DatabaseContext.News.Where(x => x.IsDeleted == false && x.Public==isPublic).OrderByDescending(x=>x.CreatedAt).Take(5));
        }

        public async Task<List<NewDto>> GetForPaginationAsync(BaseSearchObject searchObject, int pageSize, int offeset)
        {
            if(searchObject.SearchFilter!=null)
            {
                searchObject.SearchFilter = searchObject.SearchFilter.ToLower();
            }
            else
            {
                searchObject.SearchFilter = "";
            }
            var list= await ProjectToListAsync<NewDto>(DatabaseContext.News.Where(x => x.IsDeleted == false && x.Name.ToLower().Contains(searchObject.SearchFilter)).Skip(offeset).Take(pageSize));
            if (list.Count > 0)
            {
                list.First().TotalRecordsCount = DatabaseContext.News.Where(x => x.IsDeleted == false).Count();
            }
            return list;
        }
    }
}
