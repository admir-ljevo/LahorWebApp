using Lahor.API.Services.FileManager;
using Lahor.Core.Dto;
using Lahor.Core.Dto.Note;
using Lahor.Services.ApplicationUsersService;
using Lahor.Services.BaseService;
using Lahor.Services.NotificationsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Lahor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IFileManager _fileManager;
        private readonly IApplicationUsersService ApplicationUsersService;
        private readonly INotificationsService NotificationsService;
        private IHubContext<NotificationsHub> _notificationHub;
        public ClientsController(IFileManager fileManager, IApplicationUsersService applicationUsersService, IHubContext<NotificationsHub> notificationHub,INotificationsService notificationsService)
        {
            _fileManager = fileManager;
            ApplicationUsersService = applicationUsersService;
            _notificationHub = notificationHub;
            NotificationsService = notificationsService;
        }


        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {          
            return Ok(await ApplicationUsersService.GetClients());
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            return Ok(await ApplicationUsersService.GetByIdAsync(id));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ClientInsertDto entity)
        {
            var newClient = await ApplicationUsersService.AddClientAsync(entity);
            var notification = await NotificationsService.AddAsync(new NotificationDto
            {
                Text = "Novi klijent je registrovan " + entity.FirstName + " " + entity.LastName,
                IsRead=false
            });
            _notificationHub.Clients.All.SendAsync("notificationsData", notification);
            return Ok(newClient);
        }
    }
}
