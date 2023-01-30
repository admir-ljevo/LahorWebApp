using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.PersonsRepository
{
    public interface IPersonsRepository : IBaseRepository<Person, int>
    {
    }
}
