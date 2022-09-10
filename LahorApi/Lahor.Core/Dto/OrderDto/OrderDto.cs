
namespace Lahor.Core.Dto.OrderDto
{
    public class OrderDto:BaseDto
    {
        public string Name { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool Delivered { get; set; }
        public float Price { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }
        public string ClientName { get; set; }
        public bool Online { get; set; }
        public ApplicationUserDto Employee { get; set; }
        public int EmployeeId { get; set; }
        public ApplicationUserDto Client { get; set; }
        public int ClientId { get; set; }
    }
}
