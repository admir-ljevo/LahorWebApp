using Lahor.Core.Dto.OrdersServicesLevels;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Infrastructure.Repositories.OrdersServicesLevelsRepository
{
    public interface IOrdersServicesLevelsRepository : IBaseRepository<OrdersServicesLevels, int>
    {
        new Task<List<OrdersServicesLevelsDto>> GetAllAsync();
        Task<List<OrdersServicesLevelsDto>> GetByName(string name);
        Task<OrdersServicesLevelsDto> GetByIdAsync(int id);

        Task<List<OrdersServicesLevelsDto>> GetByOrderId(int id);

        Task<List<OrdersServicesLevelsDto>> GetForPaginationAsync(string searchFilter, int pageSize, int offeset)
           => throw new NotImplementedException();

    }
}
