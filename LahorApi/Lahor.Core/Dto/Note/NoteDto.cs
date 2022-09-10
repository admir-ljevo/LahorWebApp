
namespace Lahor.Core.Dto.Note
{
    public class NoteDto:BaseDto
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public ApplicationUserDto User { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
        public bool Public { get; set; }
    }
}
