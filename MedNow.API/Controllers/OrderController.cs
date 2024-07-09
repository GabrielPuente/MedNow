using MedNow.Application.Commands.Order;
using MedNow.Application.Contracts.Queries;
using MedNow.Application.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedNow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderQuery _orderQuery;
        private readonly ICachingService _cache;

        public OrderController(IOrderService orderService, IOrderQuery orderQuery, ICachingService cache)
        {
            _orderService = orderService;
            _orderQuery = orderQuery;
            _cache = cache;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            //IDEMPOTENCIA
            var cache = await _cache.GetAsync(string.Concat(command.UserId, "+", string.Join('+', command.Products.Select(x => x.Id).ToString())));
            if (!string.IsNullOrEmpty(cache))
                return Ok(cache);

            var response = await _orderService.CreateOrder(command);

            if (!response.IsValid)
                return BadRequest(response);

            await _cache.SetAsync(string.Concat(command.UserId, "+", string.Join('+', command.Products.Select(x => x.Id).ToString())), response);
            
            return Ok(response);
        }

        [HttpGet("User/{userId:guid}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var response = await _orderQuery.Get(userId);
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _orderQuery.GetById(id);
            return Ok(response);
        }
    }
}
