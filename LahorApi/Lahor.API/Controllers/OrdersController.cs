using AutoMapper;
using Lahor.API.Services.UserManager;
using Lahor.Core.Dto.OrderDto;
using Lahor.Services.OrdersService;

namespace Lahor.API.Controllers
{
    public class OrdersController : BaseController<OrderDto, OrderUpsertDto, OrderUpsertDto>
    {
        public OrdersController(IOrdersService baseService, IMapper mapper) : base(baseService, mapper)
        {
        }
    }
}
