
namespace Lahor.Core.Dto.Service
{
    public class ServiceUpsertDto:BaseDto
    {
        public string Name { get; set; }
        public int TypeOfServiceId { get; set; }
        public float Price1 { get; set; }
        public float Price2 { get; set; }
        public float Price3 { get; set; }
        public float Price4 { get; set; }
        public float Price5 { get; set; }
        public float Price6 { get; set; }
    }
}
