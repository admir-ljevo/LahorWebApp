using AutoMapper;
using Lahor.Core.Dto.ServicesLevelsPrices;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Lahor.Infrastructure.Repositories.ServicesLevelsPriceRepository
{
    public class ServicesLevelsPriceRepository : BaseRepository<ServicesLevelsPrice, int>, IServicesLevelsPriceRepository
    {
        public ServicesLevelsPriceRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }

        public async Task<ServicesLevelsPriceDto> GetByIdAsync(int id)
        {

            var servicesLevelsPrice = await ProjectToFirstOrDefaultAsync<ServicesLevelsPriceDto>(DatabaseContext.ServicesLevelsPrice.Where(x=>x.Id==id && x.IsDeleted==false));
            return servicesLevelsPrice;
        }

        public Task<List<ServicesLevelsPriceDto>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async new Task<List<ServicesLevelsPriceDto>> GetAllAsync()
        {
            return await ProjectToListAsync<ServicesLevelsPriceDto>(DatabaseContext.ServicesLevelsPrice.Include(x=>x.LevelOfServiceExecution).Where(x=>x.IsDeleted==false));
        }

        public async Task<List<ServicesLevelsPriceDto>> GetServicesLevelsByServiceId(int serviceId)
        {
            return await ProjectToListAsync<ServicesLevelsPriceDto>(DatabaseContext.ServicesLevelsPrice.Include(x => x.LevelOfServiceExecution).Where(x => x.IsDeleted == false && x.ServiceId==serviceId));
        }
    }
}
