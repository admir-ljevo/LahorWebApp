using Lahor.API.Services.FileManager;
using Lahor.Services.ApplicationUsersService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lahor.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class ApplicationUsersController : ControllerBase
    {
        private readonly IFileManager _fileManager;
        private readonly IApplicationUsersService  ApplicationUsersService;
        public ApplicationUsersController(IFileManager fileManager,IApplicationUsersService applicationUsersService)
        {
            _fileManager = fileManager;
            ApplicationUsersService = applicationUsersService;
        }

        [HttpGet("GetUserProfile")]
        public async Task<IActionResult> GetUserProfile()
        {
            if (User.Claims == null)
            {
                return BadRequest(null);
            }
           
            return Ok(await ApplicationUsersService.GetByIdAsync(int.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value)));
        }

        [HttpPut("ChangeProfilePhoto")]
        public async Task<IActionResult> ChangeProfilePhoto(IFormFile file)
        {
            if (User.Claims == null)
            {
                return BadRequest("SHARED.CHANGE_PHOTO_ERROR");
            }

            var user = await ApplicationUsersService.GetByIdAsync(int.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value));

            if (file != null)
            {
                user.Person.ProfilePhoto = await _fileManager.UploadFile(file);
                user.Person.ProfilePhotoThumbnail = user.Person.ProfilePhoto;
            }

            await ApplicationUsersService.ChangePhoto(user);

            return Ok("SHARED.CHANGE_PHOTO_SUCCESS");
        }

    }
}
