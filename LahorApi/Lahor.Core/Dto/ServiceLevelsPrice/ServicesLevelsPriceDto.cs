using Lahor.Core.Dto.LevelOfServiceExecution;
using Lahor.Core.Dto.Service;

namespace Lahor.Core.Dto.ServicesLevelsPrices
{
    public class ServicesLevelsPriceDto:BaseDto
    {
        public int ServiceId { get; set; }
        public ServiceDto Service { get; set; }
        public LevelOfServiceExecutionDto LevelOfServiceExecution { get; set; }
        public int LevelOfServiceExecutionId { get; set; }
        public float Price { get; set; }
    }
}
