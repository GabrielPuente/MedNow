using MedNow.Domain.Commands.Order;
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

        public OrderController(IOrderService orderService, IOrderQuery orderQuery)
        {
            _orderService = orderService;
            _orderQuery = orderQuery;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            var response = await _orderService.CreateOrder(command);

            if (!response.IsValid)
            {
                return BadRequest(response);
            }

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
