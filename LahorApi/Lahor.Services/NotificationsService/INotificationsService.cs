using Lahor.Core.Dto.Note;
using Lahor.Services.BaseService;

namespace Lahor.Services.NotificationsService
{
    public interface INotificationsService : IBaseService<NotificationDto>
    {
        Task<List<NotificationDto>> GetByNameAsync(string name);
        Task<List<NotificationDto>> GetUnreadNotifications();
        Task MarkAllNotificatiosAsRead();
    }
}
