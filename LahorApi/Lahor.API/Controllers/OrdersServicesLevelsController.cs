using AutoMapper;
using Lahor.Core.Dto.OrdersServicesLevels;
using Lahor.Core.SearchObjects;
using Lahor.Services.OrdersServicesLevelsService;
using Microsoft.AspNetCore.Mvc;

namespace Lahor.API.Controllers
{

    public class OrdersServicesLevelsController : BaseController<OrdersServicesLevelsDto, OrdersServiceLevelsUpsertDto, OrdersServiceLevelsUpsertDto, BaseSearchObject>
    {
        private readonly IOrdersServicesLevelsService OrdersServicesLevelsService;
        public OrdersServicesLevelsController(IOrdersServicesLevelsService baseService, IMapper mapper) : base(baseService, mapper)
        {
            OrdersServicesLevelsService = baseService;
        } 
        [HttpGet("orderId/{orderId:int}")]
        public async Task<IActionResult> GetByOrderId(int orderId)
        {
            return Ok(await OrdersServicesLevelsService.GetByOrderId(orderId));
        }
    }
}
