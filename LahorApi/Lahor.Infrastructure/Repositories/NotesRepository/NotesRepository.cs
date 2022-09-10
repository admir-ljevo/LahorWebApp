using AutoMapper;
using Lahor.Core.Dto.Note;
using Lahor.Core.Entities;
using Lahor.Infrastructure.Repositories.BaseRepository;

namespace Lahor.Infrastructure.Repositories.NotesRepository
{
    public class NotesRepository : BaseRepository<Note, int>, INotesRepository
    {
        public NotesRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }

        public Task<NoteDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<NoteDto>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async new Task<List<NoteDto>> GetAllAsync()
        {
            return await ProjectToListAsync<NoteDto>(DatabaseContext.Notes);
        }
    }
}
