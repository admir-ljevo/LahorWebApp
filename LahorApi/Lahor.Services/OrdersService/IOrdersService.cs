using Lahor.Core.Dto.Order;
using Lahor.Services.BaseService;

namespace Lahor.Services.OrdersService
{
    public interface IOrdersService : IBaseService<OrderDto>
    {
        Task<List<OrderDto>> GetByNameAsync(string name);
    }
}
