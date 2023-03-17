using AutoMapper;
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
    public class PurchaseRequestRepository : BaseRepository<PurchaseRequest, int>, IPurchaseRequestRepository
    {
        public PurchaseRequestRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }

        public async Task<PurchaseRequestDto> GetByIdAsync(int id)
        {
            return await ProjectToFirstOrDefaultAsync<PurchaseRequestDto>(DatabaseContext.PurchaseRequest.Where(pr => pr.Id == id));
        }

        public async Task<List<PurchaseRequestDto>> GetByName(string name)
        {
            return await ProjectToListAsync<PurchaseRequestDto>(DatabaseContext.PurchaseRequest.Where(pr => pr.Name == name));


        }

        public async Task<List<PurchaseRequestDto>> GetAllAsync()
        {
            return await ProjectToListAsync<PurchaseRequestDto>(DatabaseContext.PurchaseRequest.Where(pr=>pr.IsDeleted==false));
        }

        public Task<List<PurchaseRequestDto>> GetForPaginationAsync(BaseSearchObject searchFilter, int pageSize, int offset)
        { 
            return  ProjectToListAsync<PurchaseRequestDto>(DatabaseContext.PurchaseRequest.Where(pr=>!pr.IsDeleted).Skip(offset).Take(pageSize));
        }
    }
}
