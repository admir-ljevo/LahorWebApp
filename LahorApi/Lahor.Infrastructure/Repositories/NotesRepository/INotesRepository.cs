using Lahor.Core.Dto.Note;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.NotesRepository
{
    public interface INotesRepository : IBaseRepository<Note, int>
    {
        new Task<List<NoteDto>> GetAllAsync();
        Task<List<NoteDto>> GetByName(string name);
        Task<NoteDto> GetByIdAsync(int id);
        Task<List<NoteDto>> GetForPaginationAsync(string searchFilter, int pageSize, int offeset)
            => throw new NotImplementedException();
    }

}
