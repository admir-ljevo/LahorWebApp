using AutoMapper;
using Lahor.API.Services.FileManager;
using Lahor.Core.Dto.City;
using Lahor.Core.SearchObjects;
using Lahor.Services.CitiesService;

namespace Lahor.API.Controllers
{
    public class CitiesController : BaseController<CityDto, CityInsertDto, CityUpdateDto, CountriesCitiesSearchObject>
    {
        private readonly IFileManager _fileManager;
        private readonly ICitiesService citiesService;
        private readonly IMapper Mapper;
        public CitiesController(IFileManager fileManager,ICitiesService baseService, IMapper mapper) : base(baseService, mapper)
        {
            _fileManager = fileManager;
            citiesService = baseService;
            Mapper = mapper;
        }

    }
}
