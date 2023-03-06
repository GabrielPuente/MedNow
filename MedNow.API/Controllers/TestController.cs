using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rebus.Bus;
using MedNow.Application.InternalEvent;
using MedNow.Application.Contracts.Services;
using Newtonsoft.Json;

namespace MedNow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TestController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly ICachingService _cache;

        public TestController(IBus bus, ICachingService cache)
        {
            _bus = bus;
            _cache = cache;
        }

        [HttpGet("Bus")]
        public async Task<IActionResult> Get()
        {
            var evt = new TestInternalEvent()
            {
                Nome = "Gabriel Puente",
                Email = "gapuente96@gmail.com",
                Idade = 27
            };

            await _bus.Publish(evt);

            return Ok();
        }

        [HttpGet("Redis")]
        public async Task<IActionResult> GetRedis()
        {
            var evt = new TestInternalEvent()
            {
                Nome = "Gabriel Puente",
                Email = "gapuente96@gmail.com",
                Idade = 27
            };

            var cache = await _cache.GetAsync("teste");

            if (!string.IsNullOrEmpty(cache))
                return Ok(cache);

            await _cache.SetAsync("teste", evt);

            return Ok();
        }
    }
}
