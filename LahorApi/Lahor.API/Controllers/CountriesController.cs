using AutoMapper;
using Lahor.API.Services.FileManager;
using Lahor.Core.Dto.Country;
using Lahor.Core.SearchObjects;
using Lahor.Services.CountriesService;

namespace Lahor.API.Controllers
{
    public class CountriesController : BaseController<CountryDto, CountryInsertDto, CountryUpdateDto, BaseSearchObject>
    {
        private readonly IFileManager _fileManager;
        private readonly ICountriesService countriesService;
        private readonly IMapper Mapper;
        public CountriesController(IFileManager fileManager,ICountriesService baseService, IMapper mapper) : base(baseService, mapper)
        {
            _fileManager = fileManager;
            countriesService = baseService;
            Mapper = mapper;
        }

    }
}
