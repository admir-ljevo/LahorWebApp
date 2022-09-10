using Lahor.Core.Dto.Note;
using Lahor.Services.BaseService;

namespace Lahor.Services.NotesServices
{
    public interface INotesService : IBaseService<NoteDto>
    {
        Task<List<NoteDto>> GetByNameAsync(string name);
    }
}
