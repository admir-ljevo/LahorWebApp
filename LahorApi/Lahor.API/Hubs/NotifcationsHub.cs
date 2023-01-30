using Microsoft.AspNetCore.SignalR;

namespace Lahor.API
{
    public class NotificationsHub : Hub
    {
        protected IHubContext<NotificationsHub> _context;

        public NotificationsHub(IHubContext<NotificationsHub> context)
        {
            _context = context;
        }
    }
}