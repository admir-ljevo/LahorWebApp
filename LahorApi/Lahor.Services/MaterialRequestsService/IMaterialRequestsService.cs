using Lahor.Core.Dto.MaterialRequests;
using Lahor.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Services.MaterialRequestsService
{
    public interface IMaterialRequestsService: IBaseService<MaterialRequestsDto>
    {
        Task<List<MaterialRequestsDto>> GetByNameAsync(string name);
        Task<List<MaterialRequestsDto>> GetByRequestId(int id);
    }
}
