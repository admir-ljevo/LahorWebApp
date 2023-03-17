using Lahor.Core.Dto.Material;
using Lahor.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lahor.Services.MaterialService
{
    public class MaterialService : IMaterialService
    {

        private readonly UnitOfWork unitOfWork;

        public MaterialService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = (UnitOfWork)unitOfWork;
        }

        public async Task<MaterialDto> AddAsync(MaterialDto materialDto)
        {
            materialDto = await unitOfWork.MaterialRepository.AddAsync(materialDto);
            await unitOfWork.SaveChangesAsync();
            return materialDto;
        }

        public async Task<List<MaterialDto>> GetAllAsync()
        {
            return await unitOfWork.MaterialRepository.GetAllAsync();
        }

        public async Task<List<MaterialDto>> GetAllOrdered(string sortCol,
            string sortDir,
            string? nameFilter = null
            )
        {
            return await unitOfWork.MaterialRepository.GetAllOrdered(sortCol, sortDir, nameFilter);
        }

        public async Task<MaterialDto> GetByIdAsync(int id)
        {
            return await unitOfWork.MaterialRepository.GetByIdAsync(id);
        }

        public async Task<List<MaterialDto>> GetByNameAsync(string name)
        {
            return await unitOfWork.MaterialRepository.GetByName(name);
        }

        public async Task RemoveByIdAsync(int id, bool isSoft = true)
        {
            await unitOfWork.MaterialRepository.RemoveByIdAsync(id, isSoft);
            await unitOfWork.SaveChangesAsync();
        }

        public void Update(MaterialDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<MaterialDto> UpdateAsync(MaterialDto materialDto)
        {
            unitOfWork.MaterialRepository.Update(materialDto);
            await unitOfWork.SaveChangesAsync();
            return materialDto;
        }
    }
}
