using Lahor.API.Services.UserManager;
using Lahor.Core.Entities;
using Lahor.Infrastructure.UnitOfWork;

namespace Lahor.API.Services.ActivityLogger
{
    public class ActivityLogger : IActivityLogger
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ActivityLogger(IUnitOfWork unitOfWork, IUserManager userManager, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateLog(LogDto logDto)
        {
            var log = new Log();

            var request = _httpContextAccessor.HttpContext?.Request;
            if (request != null)
            {
                log.ReferrerUrl = request.Headers["Referer"].ToString();
                log.CurrentUrl = request.Path.ToString();
                log.Controller = (string)request.RouteValues["Controller"];
                log.Action = (string)request.RouteValues["Action"];
            }

            var user = _userManager.GetUserModel();
            log.UserId = user?.Id;

            log.Message = logDto.Message;
            log.Type = logDto.LogType;
            log.RowId = logDto.RowId;
            log.TableName = logDto.TableName;
            log.ExceptionMessage = logDto.Exception?.Message;
            log.ExceptionStackTrace = logDto.Exception?.StackTrace;

            try
            {
                await _unitOfWork.LogsRepository.AddAsync(log);
                await _unitOfWork.SaveChangesAsync();
            }
            catch
            {
                //Ignored
            }
        }
    }
}
