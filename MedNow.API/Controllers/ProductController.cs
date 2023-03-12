using MedNow.Application.Contracts.Queries;
using MedNow.Application.Contracts.Services;
using MedNow.Domain.Commands.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedNow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ProductController : ControllerBase
    {
        private readonly IProductQuery _productQuery;
        private readonly IProductService _productService;

        public ProductController(IProductQuery productQuery, IProductService productService)
        {
            _productQuery = productQuery;
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            var response = await _productService.CreateProduct(command);

            if (!response.IsValid)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, UpdateProductCommand command)
        {
            var response = await _productService.UpdateProduct(id, command);

            if (!response.IsValid)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _productService.DeleteProduct(id);

            if (!response.IsValid)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _productQuery.Get();
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _productQuery.GetById(id);
            return Ok(response);
        }
    }
}
