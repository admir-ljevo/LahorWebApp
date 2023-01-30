using AutoMapper;
using Lahor.Core.Dto.Country;
using Lahor.Core.Entities;
using Lahor.Core.SearchObjects;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.CountriesRepository
{
    public class CountriesRepository : BaseRepository<Country, int>, ICountriesRepository
    {
        public CountriesRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }

        public async Task<CountryDto> GetByIdAsync(int id)
        {
            return await ProjectToFirstOrDefaultAsync<CountryDto>(DatabaseContext.Countries.Where(n => n.Id == id));
        }

        public Task<List<CountryDto>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async new Task<List<CountryDto>> GetAllAsync()
        {
            return await ProjectToListAsync<CountryDto>(DatabaseContext.Countries.Where(x=>x.IsDeleted==false));
        }

        public async Task<List<CountryDto>> GetForPaginationAsync(BaseSearchObject searchObject, int pageSize, int offeset)
        {
            if(searchObject.SearchFilter!=null)
            {
                searchObject.SearchFilter = searchObject.SearchFilter.ToLower();
            }
            else
            {
                searchObject.SearchFilter = "";
            }
            var list = await ProjectToListAsync<CountryDto>(DatabaseContext.Countries.Where(x => x.IsDeleted == false && x.Name.ToLower().Contains(searchObject.SearchFilter)).Skip(offeset).Take(pageSize));
            if (list.Count>0)
            {
                list.First().TotalRecordsCount= DatabaseContext.Countries.Where(x => x.IsDeleted == false).Count();
            }
            return list;
        }
    }
}
