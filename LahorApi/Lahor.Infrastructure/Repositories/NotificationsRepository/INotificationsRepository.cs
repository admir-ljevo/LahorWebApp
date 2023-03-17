using Lahor.Core.Dto.Note;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.NotificationsRepository
{
    public interface INotificationsRepository : IBaseRepository<Notification, int>
    {
        new Task<List<NotificationDto>> GetAllAsync();
        Task<List<NotificationDto>> GetByName(string name);
        Task<NotificationDto> GetByIdAsync(int id);
        Task<List<NotificationDto>> GetForPaginationAsync(string searchFilter, int pageSize, int offeset)
            => throw new NotImplementedException();
        new Task<List<NotificationDto>> GetUnreadNotifications();

    }

}
