using Lahor.Core.Dto.Note;
using Lahor.Core.Entities;
using Lahor.Infrastructure.UnitOfWork;

namespace Lahor.Services.NotificationsService
{
    public class NotificationsService: INotificationsService
    {
        private readonly UnitOfWork _unitOfWork;

        public NotificationsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public async Task<NotificationDto> AddAsync(NotificationDto notification)
        {
            notification = await _unitOfWork.NotificationsRepository.AddAsync(notification);
            await _unitOfWork.SaveChangesAsync();
            return notification;
        }

        public async Task MarkAllNotificatiosAsRead()
        {
            await _unitOfWork.ExecuteAsync(async () =>
            {
                var notifications = await GetUnreadNotifications();
                notifications = notifications.Select(x =>
                {
                    if (!x.IsRead)
                        x.IsRead = true;
                    return x;
                }).ToList();

                _unitOfWork.NotificationsRepository.UpdateRange(notifications);
            });
        }

        public Task<NotificationDto> GetByIdAsync(int id)
        {
            return _unitOfWork.NotificationsRepository.GetByIdAsync(id);
        }

        public Task<List<NotificationDto>> GetAllAsync()
        {
            return _unitOfWork.NotificationsRepository.GetAllAsync();
        }

        public Task<List<NotificationDto>> GetUnreadNotifications()
        {
            return _unitOfWork.NotificationsRepository.GetUnreadNotifications();
        }

        public Task<List<NotificationDto>> GetByNameAsync(string name)
        {
            return _unitOfWork.NotificationsRepository.GetByName(name);
        }
        public Task<List<NotificationDto>> GetForPaginationAsync(string searchFilter, int pageSize, int offeset)
        {
            return _unitOfWork.NotificationsRepository.GetForPaginationAsync(searchFilter, pageSize, offeset);
        }

        public async Task RemoveByIdAsync(int id, bool isSoft = true)
        {
            await _unitOfWork.NotificationsRepository.RemoveByIdAsync(id, isSoft);
            await _unitOfWork.SaveChangesAsync();
        }

        public void Update(NotificationDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
