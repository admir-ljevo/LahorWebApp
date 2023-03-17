using Lahor.Core.Dto.Material;
using Lahor.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Services.MaterialService
{
    public interface IMaterialService : IBaseService<MaterialDto>
    {
        Task<List<MaterialDto>> GetByNameAsync(string name);
        Task<List<MaterialDto>> GetAllOrdered(string sortCol,
            string sortDir,
            string? nameFilter = null);
    }
}
