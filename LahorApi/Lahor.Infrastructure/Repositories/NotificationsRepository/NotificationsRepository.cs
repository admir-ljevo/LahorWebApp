using AutoMapper;
using Lahor.Core.Dto.Note;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.NotificationsRepository
{
    public class NotificationsRepository : BaseRepository<Notification, int>, INotificationsRepository
    {
        public NotificationsRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }

        public Task<NotificationDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<NotificationDto>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async new Task<List<NotificationDto>> GetAllAsync()
        {
            return await ProjectToListAsync<NotificationDto>(DatabaseContext.Notifications);
        }

        public async Task<List<NotificationDto>> GetUnreadNotifications()
        {
            return await ProjectToListAsync<NotificationDto>(DatabaseContext.Notifications.Where(x=>x.IsDeleted==false && x.IsRead==false));
        }
    }
}
