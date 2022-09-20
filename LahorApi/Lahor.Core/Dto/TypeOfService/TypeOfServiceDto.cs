using Lahor.Core.Dto.Service;

namespace Lahor.Core.Dto.TypeOfService
{
    public class TypeOfServiceDto:BaseDto
    {
        public string Name { get; set; }
        public List<ServiceDto> Services { get; set; }
    }
}
