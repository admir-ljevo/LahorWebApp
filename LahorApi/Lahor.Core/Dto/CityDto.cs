
namespace Lahor.Core.Dto
{
    public class CityDto:BaseDto
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public CountryDto Country { get; set; }
    }
}
