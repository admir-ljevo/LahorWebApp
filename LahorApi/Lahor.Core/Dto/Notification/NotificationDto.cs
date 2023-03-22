namespace Lahor.Core.Dto.Note
{
    public class NotificationDto:BaseDto
    {
        public string Text { get; set; }
        public bool IsRead { get; set; }
    }
}
