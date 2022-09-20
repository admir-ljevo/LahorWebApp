using AutoMapper;
using Lahor.API.Services.FileManager;
using Lahor.Core.Dto.New;
using Lahor.Core.SearchObjects;
using Lahor.Services.NewsService;
using Microsoft.AspNetCore.Mvc;

namespace Lahor.API.Controllers
{
    public class NewsController : BaseController<NewDto, NewInsertDto, NewUpdateDto, BaseSearchObject>
    {
        private readonly IFileManager _fileManager;
        private readonly INewsService newsService;
        private readonly IMapper Mapper;
        public NewsController(IFileManager fileManager,INewsService baseService, IMapper mapper) : base(baseService, mapper)
        {
            _fileManager = fileManager;
            newsService = baseService;
            Mapper = mapper;
        }

        [HttpPost("Add")]
        public async Task<NewDto> Add([FromForm] NewInsertDto newDto)
        {
            if (newDto.File != null)
            {
                newDto.Image = await _fileManager.UploadFile(newDto.File);
            }
            return await newsService.AddAsync(Mapper.Map<NewDto>(newDto));
        }

    }
}
