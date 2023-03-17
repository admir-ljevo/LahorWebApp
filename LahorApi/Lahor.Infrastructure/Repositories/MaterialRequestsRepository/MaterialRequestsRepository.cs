using AutoMapper;
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
    public class MaterialRequestsRepository : BaseRepository<MaterialRequests, int>, IMaterialRequestsRepository
    {
        public MaterialRequestsRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }

        public async Task<MaterialRequestsDto> GetByIdAsync(int id)
        {
            return await ProjectToFirstOrDefaultAsync<MaterialRequestsDto>(DatabaseContext.MaterialRequests.Where(mr => mr.Id == id));
        }

        public Task<List<MaterialRequestsDto>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
        
        public async Task<List<MaterialRequestsDto>> GetAllAsync()
        {
            return await ProjectToListAsync<MaterialRequestsDto>(DatabaseContext.MaterialRequests);
        }

        public async Task<List<MaterialRequestsDto>> GetByRequestId(int id)
        {
            return await ProjectToListAsync<MaterialRequestsDto>(DatabaseContext.MaterialRequests.Where(mr=> mr.PurchaseRequestId == id &&
            mr.IsDeleted==false));
        }
    }
}
