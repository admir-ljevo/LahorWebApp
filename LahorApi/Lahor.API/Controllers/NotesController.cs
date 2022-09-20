using AutoMapper;
using Lahor.Core.Dto.Note;
using Lahor.Core.SearchObjects;
using Lahor.Services.NotesServices;

namespace Lahor.API.Controllers
{
    public class NotesController : BaseController<NoteDto, NoteInsertDto, NoteUpdateDto,BaseSearchObject>
    {
        public NotesController(INotesService baseService, IMapper mapper) : base(baseService, mapper)
        {

        }

    }
}
