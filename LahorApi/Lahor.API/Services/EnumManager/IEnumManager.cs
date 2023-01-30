using Lahor.Core.Dto;

namespace Lahor.API.Services.EnumManager
{
    public interface IEnumManager
    {
        List<EntityItemDto> DrivingLicenses();
        List<EntityItemDto> Genders();
        List<EntityItemDto> Positions();
        List<EntityItemDto> MarriageStatuses();
    }
}