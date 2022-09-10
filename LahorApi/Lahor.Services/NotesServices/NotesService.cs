using Lahor.Core.Dto.Note;
using Lahor.Infrastructure.UnitOfWork;

namespace Lahor.Services.NotesServices
{
    public class NotesService:INotesService
    {
        private readonly UnitOfWork _unitOfWork;

        public NotesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public async Task<NoteDto> AddAsync(NoteDto note)
        {
            note = await _unitOfWork.NotesRepository.AddAsync(note);
            await _unitOfWork.SaveChangesAsync();
            return note;
        }

        public Task<NoteDto> GetByIdAsync(int id)
        {
            return _unitOfWork.NotesRepository.GetByIdAsync(id);
        }

        public Task<List<NoteDto>> GetAllAsync()
        {
            return _unitOfWork.NotesRepository.GetAllAsync();
        }

        public Task<List<NoteDto>> GetByNameAsync(string name)
        {
            return _unitOfWork.NotesRepository.GetByName(name);
        }
        public Task<List<NoteDto>> GetForPaginationAsync(string searchFilter, int pageSize, int offeset)
        {
            return _unitOfWork.NotesRepository.GetForPaginationAsync(searchFilter, pageSize, offeset);
        }

        public async Task RemoveByIdAsync(int id, bool isSoft = true)
        {
            await _unitOfWork.NotesRepository.RemoveByIdAsync(id, isSoft);
            await _unitOfWork.SaveChangesAsync();
        }

        public void Update(NoteDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
