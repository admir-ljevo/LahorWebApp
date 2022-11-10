
namespace Lahor.Core.Entities.Base
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        bool? IsDeleted { get; set; }
        DateTime? ModifiedAt { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
