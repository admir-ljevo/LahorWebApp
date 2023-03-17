using Lahor.Core.Dto.Material;
using Lahor.Core.Dto.PurchaseRequest;
using Lahor.Core.Entities;
using Lahor.Core.SearchObjects;
using Lahor.Infrastructure.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Infrastructure.Repositories.PurchaseRequestRepository
{
    public interface IPurchaseRequestRepository: IBaseRepository<PurchaseRequest, int>
    {
        new Task<List<PurchaseRequestDto>> GetAllAsync();
        Task<List<PurchaseRequestDto>> GetByName(string name);
        Task<PurchaseRequestDto> GetByIdAsync(int id);

        Task<List<PurchaseRequestDto>> GetForPaginationAsync(BaseSearchObject searchFilter, int pageSize, int offset);

    }
}
