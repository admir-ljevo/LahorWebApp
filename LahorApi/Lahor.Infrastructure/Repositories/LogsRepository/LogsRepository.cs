using AutoMapper;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.LogsRepository
{
    public class LogsRepository : BaseRepository<Log, int>, ILogsRepository
    {
        public LogsRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {

        }
    }
}
