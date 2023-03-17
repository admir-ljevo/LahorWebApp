using AutoMapper;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.PersonsRepository
{
    public class PersonsRepository : BaseRepository<Person, int>, IPersonsRepository
    {
        public PersonsRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }


    }
}
