using AutoMapper;
using Lahor.Core.Dto.Service;
using Lahor.Core.Dto.ServicesLevelsPrices;
using Lahor.Core.Entities;
using Lahor.Core.SearchObjects;
using Lahor.Infrastructure.Repositories.BaseRepository;
using Lahor.Shared.Constants;
using Microsoft.EntityFrameworkCore;

namespace Lahor.Infrastructure.Repositories.ServicesRepository
{
    public class ServicesRepository : BaseRepository<Service, int>, IServicesRepository
    {
        public ServicesRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }

        public async Task<ServiceDto> GetByIdAsync(int id)
        {

            var service = await ProjectToFirstOrDefaultAsync<ServiceDto>(DatabaseContext.Services.Where(x => x.Id == id && x.IsDeleted == false));
            var servicesLevelsList = await ProjectToListAsync<ServicesLevelsPriceDto>(DatabaseContext.ServicesLevelsPrice.Include(x => x.LevelOfServiceExecution).Where(x => x.IsDeleted == false && x.ServiceId == service.Id));
            if (service != null)
            {
                foreach (var item in servicesLevelsList)
                {
                    if (item.LevelOfServiceExecution.Name == LevelOfServiceExecutionNames.Pranje)
                    {
                        service.Price1 = item.Price;
                    }
                    else if (item.LevelOfServiceExecution.Name == LevelOfServiceExecutionNames.Susenje)
                    {
                        service.Price2 = item.Price;
                    }
                    else if (item.LevelOfServiceExecution.Name == LevelOfServiceExecutionNames.Peglanje)
                    {
                        service.Price3 = item.Price;
                    }
                    else if (item.LevelOfServiceExecution.Name == LevelOfServiceExecutionNames.PranjeSusenje)
                    {
                        service.Price4 = item.Price;
                    }
                    else if (item.LevelOfServiceExecution.Name == LevelOfServiceExecutionNames.SusenjePeglanje)
                    {
                        service.Price5 = item.Price;
                    }
                    else if (item.LevelOfServiceExecution.Name == LevelOfServiceExecutionNames.PranjeSusenjePeglanje)
                    {
                        service.Price6 = item.Price;
                    }
                }
            }
            return service;
        }

        public Task<List<ServiceDto>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async new Task<List<ServiceDto>> GetAllAsync()
        {
            var servicesList = await ProjectToListAsync<ServiceDto>(DatabaseContext.Services.Where(x => x.IsDeleted == false).Skip(5).Take(5));

            //var servicesLevelsList= await ProjectToListAsync<ServicesLevelsPriceDto>(DatabaseContext.ServicesLevelsPrice.Include(x=>x.LevelOfServiceExecution).Where(x => x.IsDeleted == false));

            //servicesList = servicesList.Select(x =>
            //{
            //    x.LevelsPrices=servicesLevelsList.Where(sl=>sl.ServiceId==x.Id).ToList();
            //    return x;
            //}).ToList();

            return servicesList;

        }

        public async Task<List<ServiceDto>> GetForPaginationAsync(BaseSearchObject searchObject, int pageSize, int offeset)
        {
            return await ProjectToListAsync<ServiceDto>(DatabaseContext.Services.Where(x => x.IsDeleted == false).Skip(offeset).Take(pageSize));
        }
    }
}
