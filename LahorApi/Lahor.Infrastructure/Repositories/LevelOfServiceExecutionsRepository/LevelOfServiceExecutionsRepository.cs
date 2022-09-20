using AutoMapper;
using Lahor.Core.Dto.LevelOfServiceExecution;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.LevelOfServiceExecutionsRepository
{
    public class LevelOfServiceExecutionsRepository : BaseRepository<LevelOfServiceExecution, int>, ILevelOfServiceExecutionsRepository
    {
        public LevelOfServiceExecutionsRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }

        public async Task<LevelOfServiceExecutionDto> GetByIdAsync(int id)
        {

            var levelOfServiceExecutions = await ProjectToFirstOrDefaultAsync<LevelOfServiceExecutionDto>(DatabaseContext.LevelOfServiceExecution.Where(x=>x.Id==id && x.IsDeleted==false));
            return levelOfServiceExecutions;
        }

        public Task<List<LevelOfServiceExecutionDto>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async new Task<List<LevelOfServiceExecutionDto>> GetAllAsync()
        {
            return await ProjectToListAsync<LevelOfServiceExecutionDto>(DatabaseContext.LevelOfServiceExecution.Where(x=>x.IsDeleted==false));
        }
    }
}
