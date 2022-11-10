using AutoMapper;
using Lahor.API.Services.FileManager;
using Lahor.Core.Dto.New;
using Lahor.Core.SearchObjects;
using Lahor.Services.NewsService;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

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
            var file = newDto.File;
            if (file != null)
            {
                newDto.Image = await _fileManager.UploadFile(file);
            }
            return await newsService.AddAsync(Mapper.Map<NewDto>(newDto));
        }

        [HttpPut("Edit/{id}")]
        public async Task<NewDto> Put(int id,[FromForm] NewUpdateDto newDto)
        {
            var file = newDto.File;
            if (file != null)
            {
                newDto.Image = await _fileManager.UploadFile(file);
            }
            return await newsService.UpdateAsync(Mapper.Map<NewDto>(newDto));
        }

    }
}
