using Lahor.Core.Dto.MaterialRequests;
using Lahor.Infrastructure.UnitOfWork;
using Lahor.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Services.MaterialRequestsService
{
    public class MaterialRequestsService : IMaterialRequestsService
    {
        private readonly UnitOfWork unitOfWork;
        public MaterialRequestsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = (UnitOfWork)unitOfWork;
        }
        public async Task<MaterialRequestsDto> AddAsync(MaterialRequestsDto materialRequestDto)
        {
            materialRequestDto = await unitOfWork.MaterialRequestsRepository.AddAsync(materialRequestDto);
            await unitOfWork.SaveChangesAsync();
            return materialRequestDto;

        }

        public Task<List<MaterialRequestsDto>> GetAllAsync()
        {
            return unitOfWork.MaterialRequestsRepository.GetAllAsync();
        }

        public async Task<MaterialRequestsDto> GetByIdAsync(int id)
        {
            return await unitOfWork.MaterialRequestsRepository.GetByIdAsync(id);
        }

        public Task<List<MaterialRequestsDto>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<MaterialRequestsDto>> GetByRequestId(int id)
        {
            return unitOfWork.MaterialRequestsRepository.GetByRequestId(id);
        }

        public async Task RemoveByIdAsync(int id, bool isSoft = true)
        {
            await unitOfWork.MaterialRequestsRepository.RemoveByIdAsync(id, isSoft);
            await unitOfWork.SaveChangesAsync();
        }

        public void Update(MaterialRequestsDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<MaterialRequestsDto> UpdateAsync(MaterialRequestsDto materialRequestDto)
        {
            unitOfWork.MaterialRequestsRepository.Update(materialRequestDto);
            await unitOfWork.SaveChangesAsync();
            return materialRequestDto;
        }
    }
}
