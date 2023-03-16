using Lahor.Core.Dto.OrdersServicesLevels;
using Lahor.Core.Entities;
using Lahor.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Services.OrdersServicesLevelsService
{
    public interface IOrdersServicesLevelsService : IBaseService<OrdersServicesLevelsDto>
    {
        Task<List<OrdersServicesLevelsDto>> GetByNameAsync(string name);
        Task<List<OrdersServicesLevelsDto>> GetByOrderId(int id);
    }
}
