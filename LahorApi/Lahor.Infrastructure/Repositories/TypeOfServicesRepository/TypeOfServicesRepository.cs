using AutoMapper;
using Lahor.Core.Dto.New;
using Lahor.Core.Dto.Service;
using Lahor.Core.Dto.TypeOfService;
using Lahor.Core.Dto.TypeOfServiceWithoutServices;
using Lahor.Core.Entities;
using Lahor.Core.SearchObjects;
using Lahor.Infrastructure.Repositories.BaseRepository;
using Lahor.Reporting.Models;

namespace Lahor.Infrastructure.Repositories.TypeOfServicesRepository
{
    public class TypeOfServicesRepository : BaseRepository<TypeOfService, int>, ITypeOfServicesRepository
    {
        public TypeOfServicesRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }

        public async Task<TypeOfServiceDto> GetByIdAsync(int id)
        {

            var typeOfServices = await ProjectToFirstOrDefaultAsync<TypeOfServiceDto>(DatabaseContext.TypeOfServices.Where(x=>x.Id==id && x.IsDeleted==false));
            return typeOfServices;
        }

        public Task<List<TypeOfServiceDto>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async new Task<List<TypeOfServiceDto>> GetAllAsync()
        {
            var typeOfServices= await ProjectToListAsync<TypeOfServiceDto>(DatabaseContext.TypeOfServices.Where(x=>x.IsDeleted==false));

            foreach (var item in typeOfServices)
            {
                var services = await ProjectToListAsync<ServiceDto>(DatabaseContext.Services.Where(x => x.IsDeleted == false && x.TypeOfServiceId==item.Id));
                item.Services = null;
                item.Services=services;
            }

            return typeOfServices;
        }
        public async new Task<List<TypeOfServiceDto>> GetReportData(ReportSearchObject search)
        {
            var listReportData = new List<ServiceReportModel>();
            var typeOfServices = await ProjectToListAsync<TypeOfServiceDto>(DatabaseContext.TypeOfServices.Where(x => x.IsDeleted == false));

            if (search.DateTo == null || search.DateFrom == null)
                return typeOfServices;

            foreach (var item in typeOfServices)
            {
                var services = await ProjectToListAsync<ServiceDto>(DatabaseContext.Services.Where(x => x.IsDeleted == false && x.TypeOfServiceId == item.Id && x.CreatedAt>=search.DateFrom && x.CreatedAt<=search.DateTo));
                item.Services = null;
                item.Services = services;
            }

            return typeOfServices;
        }

        public async Task<List<TypeOfServiceDto>> GetForPaginationAsync(BaseSearchObject searchObject, int pageSize, int offeset)
        {
            var list = await ProjectToListAsync<TypeOfServiceWithoutServicesDto>(DatabaseContext.TypeOfServices.Where(x => x.IsDeleted == false && (searchObject.SearchFilter == null || x.Name.ToLower().Contains(searchObject.SearchFilter.ToLower()))).Skip(offeset).Take(pageSize));
            if (list.Count > 0)
            {
                list.First().TotalRecordsCount = DatabaseContext.TypeOfServices.Where(x => x.IsDeleted == false).Count();
            }
            return Mapper.Map<List<TypeOfServiceDto>>(list);
        }

    }
}
