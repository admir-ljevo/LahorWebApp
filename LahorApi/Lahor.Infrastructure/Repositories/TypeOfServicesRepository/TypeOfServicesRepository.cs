using AutoMapper;
using Lahor.Core.Dto.TypeOfService;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.TypeOfServicesRepository
{
    public class TypeOfServicesRepository : BaseRepository<TypeOfService, int>, ITypeOfServicesRepository
    {
        public TypeOfServicesRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }

        public async Task<TypeOfServiceDto> GetByIdAsync(int id)
        {

            var typeOfServices = await ProjectToFirstOrDefaultAsync<TypeOfServiceDto>(DatabaseContext.TypeOfServices.Where(x=>x.Id==id && x.IsDeleted==false));
            return typeOfServices;
        }

        public Task<List<TypeOfServiceDto>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async new Task<List<TypeOfServiceDto>> GetAllAsync()
        {
            return await ProjectToListAsync<TypeOfServiceDto>(DatabaseContext.TypeOfServices.Where(x=>x.IsDeleted==false));
        }
    }
}
