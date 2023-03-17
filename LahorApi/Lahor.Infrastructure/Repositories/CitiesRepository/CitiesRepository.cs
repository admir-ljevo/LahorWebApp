using AutoMapper;
using Lahor.Core.Dto.City;
using Lahor.Core.Entities;
using Lahor.Core.SearchObjects;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.CitiesRepository
{
    public class CitiesRepository : BaseRepository<City, int>, ICitiesRepository
    {
        public CitiesRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }

        public async Task<CityDto> GetByIdAsync(int id)
        {

            return await ProjectToFirstOrDefaultAsync<CityDto>(DatabaseContext.Cities.Where(n => n.Id == id));
        }

        public Task<List<CityDto>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async new Task<List<CityDto>> GetAllAsync()
        {
            return await ProjectToListAsync<CityDto>(DatabaseContext.Cities.Where(x=>x.IsDeleted==false));
        }

        public async Task<List<CityDto>> GetForPaginationAsync(BaseSearchObject searchObject, int pageSize, int offeset)
        {
            var search = searchObject as CountriesCitiesSearchObject;
            //if(search.SearchFilter!=null)
            //{
            //    search.SearchFilter = searchObject.SearchFilter.ToLower();
            //}
            //else
            //{
            //    search.SearchFilter = "";
            //}
            var list= await ProjectToListAsync<CityDto>(DatabaseContext.Cities.Where(x => x.IsDeleted == false &&(search.CountryId==0 || search.CountryId==x.CountryId)&&(search.SearchFilter==null || x.Name.ToLower().Contains(search.SearchFilter.ToLower()))).Skip(offeset).Take(pageSize));
            if (list.Count > 0)
            {
                list.First().TotalRecordsCount = DatabaseContext.Cities.Where(x => x.IsDeleted == false).Count();
            }
            return list;
        }
    }
}
