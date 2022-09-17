using Lahor.Core.Dto.TypeOfService;

namespace Lahor.Core.Dto.Service
{
    public class ServiceDto:BaseDto
    {
        public string Name { get; set; }
        public int TypeOfServiceId { get; set; }
        public TypeOfServiceDto TypeOfService { get; set; }
    }
}
