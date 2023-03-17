using Lahor.Core.Dto.PurchaseRequest;
using Lahor.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Services.PurchaseRequestService
{
    public interface IPurchaseRequestService: IBaseService<PurchaseRequestDto>, IPaginationBaseService<PurchaseRequestDto>
    {
        Task<List<PurchaseRequestDto>> GetByNameAsync(string name);
    }
}
