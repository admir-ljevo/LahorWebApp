using Lahor.Core.Dto.Order;
using Lahor.Core.Dto.OrdersServicesLevels;
using Lahor.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Services.OrdersServicesLevelsService
{
    public class OrdersServicesLevelsService : IOrdersServicesLevelsService
    {
        private readonly UnitOfWork unitOfWork;

        public OrdersServicesLevelsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = (UnitOfWork)unitOfWork;
        }
        
        public async Task<OrdersServicesLevelsDto> AddAsync(OrdersServicesLevelsDto ordersServicesLevels)
        {
            ordersServicesLevels = await unitOfWork.OrdersServicesLevelsRepository.AddAsync(ordersServicesLevels);
            await unitOfWork.SaveChangesAsync();
            return ordersServicesLevels;
        }

        public Task<List<OrdersServicesLevelsDto>> GetAllAsync()
        {
            return unitOfWork.OrdersServicesLevelsRepository.GetAllAsync();
        }

        public async Task<OrdersServicesLevelsDto> GetByIdAsync(int id)
        {
            return await unitOfWork.OrdersServicesLevelsRepository.GetByIdAsync(id);
        }

        public Task<List<OrdersServicesLevelsDto>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrdersServicesLevelsDto>> GetByOrderId(int id)
        {
           return await   unitOfWork.OrdersServicesLevelsRepository.GetByOrderId(id);
        }

        public async Task RemoveByIdAsync(int id, bool isSoft = true)
        {
            await unitOfWork.OrdersServicesLevelsRepository.RemoveByIdAsync(id, isSoft);
            await unitOfWork.SaveChangesAsync();
        }

        public void Update(OrdersServicesLevelsDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<OrdersServicesLevelsDto> UpdateAsync(OrdersServicesLevelsDto entity)
        {
            unitOfWork.OrdersServicesLevelsRepository.Update(entity);
            await unitOfWork.SaveChangesAsync();
            return entity;
        }

    }
}
