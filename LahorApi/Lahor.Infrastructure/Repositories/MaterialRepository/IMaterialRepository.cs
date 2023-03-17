using Lahor.Core.Dto.Material;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Infrastructure.Repositories.MaterialRepository
{

    public interface IMaterialRepository : IBaseRepository<Material, int>
    {
        new Task<List<MaterialDto>> GetAllAsync();

        Task<List<MaterialDto>> GetByName(string name);
        Task<MaterialDto> GetByIdAsync(int id);
        Task<List<MaterialDto>> GetAllOrdered(string sortCol, string sortDir, string? nameFilter = null);
        Task<List<MaterialDto>> GetForPaginationAsync(string searchFilter, int pageSize, int offset) => throw new NotImplementedException();

    }
}
