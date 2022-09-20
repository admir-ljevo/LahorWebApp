using AutoMapper;
using Lahor.Core.Dto.OrderDto;
using Lahor.Core.SearchObjects;
using Lahor.Services.OrdersService;

namespace Lahor.API.Controllers
{
    public class OrdersController : BaseController<OrderDto, OrderUpsertDto, OrderUpsertDto,BaseSearchObject>
    {
        public OrdersController(IOrdersService baseService, IMapper mapper) : base(baseService, mapper)
        {
        }
    }
}
