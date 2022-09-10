using AutoMapper;
using Lahor.API.Services.UserManager;
using Lahor.Core.Dto.Note;
using Lahor.Services.NotesServices;

namespace Lahor.API.Controllers
{
    public class NotesController : BaseController<NoteDto, NoteInsertDto, NoteUpdateDto>
    {
        public NotesController(INotesService baseService, IMapper mapper) : base(baseService, mapper)
        {

        }

    }
}
