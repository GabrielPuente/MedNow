using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rebus.Bus;
using MedNow.Application.InternalEvent;

namespace MedNow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TestBusController : ControllerBase
    {
        private readonly IBus _bus;

        public TestBusController(IBus bus)
        {
            _bus = bus;
        }

        [HttpGet]
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
    }
}
