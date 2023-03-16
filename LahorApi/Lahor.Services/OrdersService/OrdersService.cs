using Lahor.Core.Dto.Order;
using Lahor.Infrastructure.UnitOfWork;

namespace Lahor.Services.OrdersService
{
    public class OrdersService:IOrdersService
    {
        private readonly UnitOfWork _unitOfWork;

        public OrdersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public async Task<OrderDto> AddAsync(OrderDto order)
        {
            order = await _unitOfWork.OrdersRepository.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();
            return order;
        }

        public Task<OrderDto> GetByIdAsync(int id)
        {
            return _unitOfWork.OrdersRepository.GetByIdAsync(id);
        }

        public Task<List<OrderDto>> GetAllAsync()
        {
            return _unitOfWork.OrdersRepository.GetAllAsync();
        }

        public Task<List<OrderDto>> GetByNameAsync(string name)
        {
            return _unitOfWork.OrdersRepository.GetByName(name);
        }
        public Task<List<OrderDto>> GetForPaginationAsync(string searchFilter, int pageSize, int offeset)
        {
            return _unitOfWork.OrdersRepository.GetForPaginationAsync(searchFilter, pageSize, offeset);
        }

        public async Task RemoveByIdAsync(int id, bool isSoft = true)
        {
            await _unitOfWork.OrdersRepository.RemoveByIdAsync(id, isSoft);
            await _unitOfWork.SaveChangesAsync();
        }

        public void Update(OrderDto entity)
        {
            _unitOfWork.OrdersRepository.Update<OrderDto>(entity);
            _unitOfWork.SaveChanges();
        }
        public async Task<OrderDto> UpdateAsync(OrderDto orderDto)
        {
            _unitOfWork.OrdersRepository.Update(orderDto);
            await _unitOfWork.SaveChangesAsync();
            return orderDto;
        }
    }
}
