using AutoMapper;
using Lahor.Core.Dto.City;
using Lahor.Core.Dto.Note;
using Lahor.Core.SearchObjects;
using Lahor.Services.BaseService;
using Lahor.Services.NewsService;
using Lahor.Services.NotificationsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Lahor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : BaseController<NotificationDto, NotificationInsertDto, NotificationUpdateDto, BaseSearchObject>
    {
        private IHubContext<NotificationsHub> _hub;
        INotificationsService NotificationsService;
        IMapper Mapper;
        public NotificationsController(IHubContext<NotificationsHub> hub,INotificationsService baseService,IMapper mapper) : base(baseService, mapper)
        {
            _hub = hub;
            NotificationsService = baseService;
            Mapper = mapper;
        }

        [HttpPost("sendNotifications")]
        public IActionResult SendNotification()
        {
            _hub.Clients.All.SendAsync("notificationsData", "Novi klijent je registrovan");

            return Ok();
        }

        [HttpGet("GetUnreadNotifications")]
        public async Task<IActionResult> GetUnreadNotifications()
        {
            return Ok(await NotificationsService.GetUnreadNotifications());
        }

        [HttpPost("MarkAllAsRead")]
        public async Task<IActionResult> MarkAllNotificatiosAsRead()
        {
            await NotificationsService.MarkAllNotificatiosAsRead();
            return Ok();
        }

    }
}
