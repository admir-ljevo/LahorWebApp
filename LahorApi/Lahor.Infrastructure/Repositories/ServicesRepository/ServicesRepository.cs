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
            return await ProjectToListAsync<ServiceDto>(DatabaseContext.Services.Where(x => x.IsDeleted == false));

        }

        public async new Task<List<ServiceDto>> GetReportData(ReportSearchObject search)
        {
                return await ProjectToListAsync<ServiceDto>(DatabaseContext.Services.Where(x => x.IsDeleted == false  && x.CreatedAt >= search.DateFrom && x.CreatedAt <= search.DateTo));
        }

        public async Task<List<ServiceDto>> GetForPaginationAsync(BaseSearchObject searchObject, int pageSize, int offeset)
        {
            var search = searchObject as ServicesSearchObject;
            var list= await ProjectToListAsync<ServiceDto>(DatabaseContext.Services.Where(x => x.IsDeleted == false && (search.SearchFilter==null || x.Name.ToLower().Contains(search.SearchFilter.ToLower())) && (search.TypeOfServiceId==0 || search.TypeOfServiceId==x.TypeOfServiceId)).Skip(offeset).Take(pageSize));
            if (list.Count > 0)
            { 
                list.First().TotalRecordsCount = DatabaseContext.Services.Where(x => x.IsDeleted == false).Count();
            }
            return list;
        }

        public async Task<List<int>> GetServicesCountByMonth()
        {
            int currentMonth = DateTime.Now.Month;
            int month;
            var listServicesCount = new List<int>();
            for (int i = currentMonth - 11; i <= currentMonth; i++)
            {
                month = i;
                if (i <= 0)
                {
                    month += 12;
                }
                listServicesCount.Add(DatabaseContext.Services.Where(x => x.IsDeleted == false && x.CreatedAt.Month == month).Count());

            }
            return listServicesCount;
        }
    }
}
