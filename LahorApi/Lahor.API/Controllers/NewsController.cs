using AutoMapper;
using Lahor.API.Services.FileManager;
using Lahor.Core.Dto.New;
using Lahor.Core.SearchObjects;
using Lahor.Services.NewsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lahor.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
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
            if (User.Claims != null)
            {
                newDto.UserId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
            }
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

        [HttpGet("GetLastFiveNews")]
        public async Task<IActionResult> GetLastFiveNews(bool isPublic)
        {
            return Ok(await newsService.GetLastFiveNews(isPublic));
        }
    }
}
