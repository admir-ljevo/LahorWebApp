using Lahor.Core.Dto.New;
using Lahor.Core.SearchObjects;
using Lahor.Infrastructure.UnitOfWork;

namespace Lahor.Services.NewsService
{
    public class NewsService : INewsService
    {
        private readonly UnitOfWork _unitOfWork;

        public NewsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public async Task<NewDto> AddAsync(NewDto note)
        {
            note = await _unitOfWork.NewsRepository.AddAsync(note);
            await _unitOfWork.SaveChangesAsync();
            return note;
        }

        public Task<NewDto> GetByIdAsync(int id)
        {
            return _unitOfWork.NewsRepository.GetByIdAsync(id);
        }

        public Task<List<NewDto>> GetAllAsync()
        {
            return _unitOfWork.NewsRepository.GetAllAsync();
        }

        public Task<List<NewDto>> GetLastFiveNews(bool isPublic)
        {
            return _unitOfWork.NewsRepository.GetLastFiveNews(isPublic);
        }

        public Task<List<NewDto>> GetByNameAsync(string name)
        {
            return _unitOfWork.NewsRepository.GetByName(name);
        }
        public async Task<List<NewDto>> GetForPaginationAsync(BaseSearchObject searchFilter, int pageSize, int offeset)
        {
            return await _unitOfWork.NewsRepository.GetForPaginationAsync(searchFilter, pageSize, offeset);
        }

        public async Task RemoveByIdAsync(int id, bool isSoft = true)
        {
            await _unitOfWork.NewsRepository.RemoveByIdAsync(id, isSoft);
            await _unitOfWork.SaveChangesAsync();
        }

        public void Update(NewDto entity)
        {
            _unitOfWork.NewsRepository.Update<NewDto>(entity);
            _unitOfWork.SaveChanges();
        }

        public async Task<NewDto> UpdateAsync(NewDto entity)
        {
            _unitOfWork.NewsRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
