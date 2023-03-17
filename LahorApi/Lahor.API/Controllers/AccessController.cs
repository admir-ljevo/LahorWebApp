using AutoMapper;
using Lahor.API.Services.ActivityLogger;
using Lahor.API.Services.AccessManager;
using Lahor.API.ViewModel;
using Lahor.Core.Enumerations;
using Lahor.Shared.Messages;
using Microsoft.AspNetCore.Mvc;

namespace Lahor.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccessController : ControllerBase
    {
        private readonly IAccessManager _accessManager;
        private readonly IActivityLogger ActivityLogger;
        public AccessController(IActivityLogger logger, IMapper mapper,IAccessManager accessManager)  /*:base(logger, mapper)*/
        {
            _accessManager = accessManager;
            ActivityLogger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AccessSignInViewModel viewModel)
        {
            if(!ModelState.IsValid)
                return BadRequest(Messages.InValidMessage);

            try
            {
                var loginInformation = await _accessManager.SignInAsync(viewModel.UserName, viewModel.Password, viewModel.RememberMe);
                if (loginInformation != null)
                {
                    return Ok(loginInformation);
                }
            }
            catch (Exception exception)
            {
                var e = exception as WrongCredentialsException;

                await LogAsync(new LogDto(LogType.UnsuccessfulSignIn, nameof(Core.Entities.Person), e?.User?.Id, Messages.Error, Messages.WrongCredentials, e));
            }
            return BadRequest(Messages.WrongCredentials);
        }
        protected async Task LogAsync(LogDto log, bool disableToastr = false, bool disableFlashMessages = true)
        {
            await ActivityLogger.CreateLog(log);

        }
    }
}
