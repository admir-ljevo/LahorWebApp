using AutoMapper;
using Lahor.Core.Dto;
using Lahor.Core.Dto.New;
using Lahor.Core.Entities;
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
    }
}
