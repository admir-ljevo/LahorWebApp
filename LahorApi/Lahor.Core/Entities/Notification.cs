using Lahor.Core.Entities.Base;

namespace Lahor.Core.Entities
{
    public class Notification:BaseEntity
    {
        public string Text { get; set; }
        public bool IsRead { get; set; }
    }
}
