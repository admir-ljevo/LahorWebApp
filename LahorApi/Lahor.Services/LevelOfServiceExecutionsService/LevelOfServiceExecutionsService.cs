
using Lahor.Core.Dto.LevelOfServiceExecution;
using Lahor.Infrastructure.UnitOfWork;
using Lahor.Services.LevelOfServiceExecutionsService;

namespace Lahor.Services.LdevelOfServiceExecutionsService
{
    public class LevelOfServiceExecutionsService : ILevelOfServiceExecutionsService
    {
        private readonly UnitOfWork _unitOfWork;

        public LevelOfServiceExecutionsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }
        public async Task<LevelOfServiceExecutionDto> AddAsync(LevelOfServiceExecutionDto entity)
        {
            entity = await _unitOfWork.LevelOfServiceExecutionsRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public Task<List<LevelOfServiceExecutionDto>> GetAllAsync()
        {
            return _unitOfWork.LevelOfServiceExecutionsRepository.GetAllAsync();
        }

        public Task<LevelOfServiceExecutionDto> GetByIdAsync(int id)
        {
           return _unitOfWork.LevelOfServiceExecutionsRepository.GetByIdAsync(id);
        }

        public Task<List<LevelOfServiceExecutionDto>> GetByNameAsync(string name)
        {
            return _unitOfWork.LevelOfServiceExecutionsRepository.GetByName(name);
        }

        public async Task RemoveByIdAsync(int id, bool isSoft = true)
        {
            await _unitOfWork.LevelOfServiceExecutionsRepository.RemoveByIdAsync(id, isSoft);
            await _unitOfWork.SaveChangesAsync();
        }

        public void Update(LevelOfServiceExecutionDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
