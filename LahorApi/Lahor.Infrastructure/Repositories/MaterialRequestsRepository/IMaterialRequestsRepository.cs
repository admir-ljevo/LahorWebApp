using Lahor.Core.Dto.Material;
using Lahor.Core.Dto.MaterialRequests;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Infrastructure.Repositories.MaterialRequestsRepository
{
    public interface IMaterialRequestsRepository: IBaseRepository<MaterialRequests, int>
    {
        new Task<List<MaterialRequestsDto>> GetAllAsync();
        Task<List<MaterialRequestsDto>> GetByNameAsync(string name);
        Task<MaterialRequestsDto> GetByIdAsync(int id);

        Task<List<MaterialRequestsDto>> GetByRequestId(int id); 

        Task<List<MaterialRequests>> GetForPaginationAsync(string searchFilter, int pageSize, int offset) => throw new NotImplementedException();

    }
}
