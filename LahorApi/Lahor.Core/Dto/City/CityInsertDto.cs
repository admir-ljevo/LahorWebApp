using Lahor.Core.Dto.Country;

namespace Lahor.Core.Dto.City
{
    public class CityInsertDto:BaseDto
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int CountryId { get; set; }
        public bool Favorite { get; set; }
    }
}
