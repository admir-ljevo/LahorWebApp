using Lahor.API.Services.EnumManager;
using Microsoft.AspNetCore.Mvc;

namespace Lahor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumController : ControllerBase
    {
        private readonly IEnumManager _enumManager;
        public EnumController(IEnumManager enumManager) {
            _enumManager = enumManager;
        }

        [HttpGet]
        [Route("genders")]
        public IActionResult Genders()
        {
            return Ok(_enumManager.Genders());

        }

        [HttpGet]
        [Route("drivingLicenses")]
        public IActionResult DrivingLicenses()
        {
            return Ok(_enumManager.DrivingLicenses());

        }

        [HttpGet]
        [Route("positions")]
        public IActionResult Positions()
        {
            return Ok(_enumManager.Positions());

        }

        [HttpGet]
        [Route("marriageStatuses")]
        public IActionResult MarriageStatuses()
        {
            return Ok(_enumManager.MarriageStatuses());

        }

    }
}
