using AutoMapper;
using Lahor.Core.Dto;
using Lahor.Core.Dto.Order;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.OrdersRepository
{
    public class OrdersRepository : BaseRepository<Order, int>, IOrdersRepository
    {
        public OrdersRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }
        public async Task<OrderDto> GetByIdAsync(int id)
        {
            var order = await ProjectToFirstOrDefaultAsync<OrderDto>(DatabaseContext.Orders.Where(o => o.Id == id));
            order.Employee = await ProjectToFirstOrDefaultAsync<ApplicationUserDto>(DatabaseContext.Persons.Where(p => p.ApplicationUserId == order.EmployeeId));
            order.Client = await ProjectToFirstOrDefaultAsync<ApplicationUserDto>(DatabaseContext.Persons.Where(p => p.ApplicationUserId == order.ClientId));
            return order;
        }

        public Task<List<OrderDto>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async new Task<List<OrderDto>> GetAllAsync()
        {
            return await ProjectToListAsync<OrderDto>(DatabaseContext.Orders);
        }
    }
}
