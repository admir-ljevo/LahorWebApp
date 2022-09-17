using AutoMapper;
using Lahor.Core.Dto.Service;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.ServicesRepository
{
    public class ServicesRepository : BaseRepository<Service, int>, IServicesRepository
    {
        public ServicesRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }

        public async Task<ServiceDto> GetByIdAsync(int id)
        {

            var news = await ProjectToFirstOrDefaultAsync<ServiceDto>(DatabaseContext.Services.Where(x=>x.Id==id && x.IsDeleted==false));
            return news;
        }

        public Task<List<ServiceDto>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async new Task<List<ServiceDto>> GetAllAsync()
        {
            return await ProjectToListAsync<ServiceDto>(DatabaseContext.Services.Where(x=>x.IsDeleted==false));
        }
    }
}
