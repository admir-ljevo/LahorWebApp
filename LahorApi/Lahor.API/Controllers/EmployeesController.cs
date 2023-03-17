using Lahor.API.Services.FileManager;
using Lahor.Core.Dto;
using Lahor.Services.ApplicationUsersService;
using Lahor.Services.BaseService;
using Microsoft.AspNetCore.Mvc;

namespace Lahor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IFileManager _fileManager;
        private readonly IApplicationUsersService ApplicationUsersService;
        public EmployeesController(IFileManager fileManager, IApplicationUsersService applicationUsersService)
        {
            _fileManager = fileManager;
            ApplicationUsersService = applicationUsersService;
        }



        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm] EmployeeInsertDto entity)
        {
            var file = entity.File;
            if (file != null)
            {
                entity.ProfilePhoto = await _fileManager.UploadFile(file);
            }
            return Ok(await ApplicationUsersService.AddEmployeeAsync(entity));
        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> Put(int id,[FromForm] EmployeeInsertDto entity)
        {
            var file = entity.File;
            if (file != null)
            {
                entity.ProfilePhoto = await _fileManager.UploadFile(file);
            }
            return Ok(await ApplicationUsersService.EditEmployee(entity));
        }


        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {          
            return Ok(await ApplicationUsersService.GetEmployees());
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            return Ok(await ApplicationUsersService.GetByIdAsync(id));
        }


        [HttpPut("Deactivate")]
        public async Task<IActionResult> Deactivate(int id)
        {

            var user = await ApplicationUsersService.GetByIdAsync(id);
            user.Active = false;
            await ApplicationUsersService.UpdateAsync(user);

            return Ok("SHARED.DEACTIVATE_SUCCESS");
        }
    }
}
