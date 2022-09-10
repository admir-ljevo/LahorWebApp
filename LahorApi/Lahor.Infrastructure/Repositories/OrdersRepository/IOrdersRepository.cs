using Lahor.Core.Dto.OrderDto;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.OrdersRepository
{
    public interface IOrdersRepository : IBaseRepository<Order, int>
    {
        new Task<List<OrderDto>> GetAllAsync();
        Task<List<OrderDto>> GetByName(string name);
        Task<OrderDto> GetByIdAsync(int id);
        Task<List<OrderDto>> GetForPaginationAsync(string searchFilter, int pageSize, int offeset)
            => throw new NotImplementedException();
    }
}
