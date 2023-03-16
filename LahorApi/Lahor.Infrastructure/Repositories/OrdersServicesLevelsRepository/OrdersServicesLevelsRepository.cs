using AutoMapper;
using Lahor.Core.Dto.LevelOfServiceExecution;
using Lahor.Core.Dto.Order;
using Lahor.Core.Dto.OrdersServicesLevels;
using Lahor.Core.Dto.Service;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Infrastructure.Repositories.OrdersServicesLevelsRepository
{
    public class OrdersServicesLevelsRepository : BaseRepository<OrdersServicesLevels, int>, IOrdersServicesLevelsRepository
    {
        public OrdersServicesLevelsRepository(IMapper mapper, DatabaseContext databaseContext): base (mapper, databaseContext)
        {
        }
        public async Task<OrdersServicesLevelsDto> GetByIdAsync(int id)
        {
            var orderServiceLevel = await ProjectToFirstOrDefaultAsync<OrdersServicesLevelsDto>(DatabaseContext.OrdersServicesLevels.Where(osl => osl.Id == id && osl.IsDeleted == false));
            orderServiceLevel.Order = await ProjectToFirstOrDefaultAsync<OrderDto>(DatabaseContext.Orders.Where(o => o.Id == orderServiceLevel.OrderId));
            orderServiceLevel.Service = await ProjectToFirstOrDefaultAsync<ServiceDto>(DatabaseContext.Services.Where(s => s.Id == orderServiceLevel.ServiceId));
            orderServiceLevel.LevelOfServiceExecution = await ProjectToFirstOrDefaultAsync<LevelOfServiceExecutionDto>(DatabaseContext.LevelOfServiceExecution.Where(s => s.Id == orderServiceLevel.LevelOfServiceExecutionId));
            return orderServiceLevel;
        }

        public async Task<List<OrdersServicesLevelsDto>> GetByOrderId(int id)
        {
            
            return await ProjectToListAsync<OrdersServicesLevelsDto>(DatabaseContext.OrdersServicesLevels.Where(osl => osl.OrderId == id && osl.IsDeleted == false));
           
        }

        public Task<List<OrdersServicesLevelsDto>> GetByName(string name)
        {
            throw new NotImplementedException();
        }
         
        public async Task<List<OrdersServicesLevelsDto>> GetAllAsync()
        {
            return await ProjectToListAsync<OrdersServicesLevelsDto>(DatabaseContext.OrdersServicesLevels);
        }
    }
}
