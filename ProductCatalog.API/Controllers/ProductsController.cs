using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Products.Commands;
using ProductCatalog.Application.Products.Queries;

namespace ProductCatalog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] ProductDto productDto)
        {
            var id = await _mediator.Send(new CreateProductCommand(productDto));
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ProductDto productDto)
        {
            await _mediator.Send(new UpdateProductCommand(id, productDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return NoContent();
        }

    }
}