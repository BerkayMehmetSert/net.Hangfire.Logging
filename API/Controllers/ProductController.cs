using API.Application.Requests;
using API.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductRequest request)
        {
            _service.CreateProduct(request);
            return Ok(new
            {
                Success = true,
                Message = "Product created successfully"
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductRequest request)
        {
            _service.UpdateProduct(id, request);
            return Ok(new
            {
                Success = true,
                Message = "Product updated successfully"
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct([FromRoute] Guid id)
        {
            _service.DeleteProduct(id);
            return Ok(new
            {
                Success = true,
                Message = "Product deleted successfully"
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById([FromRoute] Guid id)
        {
            var product = _service.GetProductById(id);
            return Ok(new
            {
                Success = true,
                Message = "Product retrieved successfully",
                Data = product
            });
        }

        [HttpGet("name/{name}")]
        public IActionResult GetProductByName([FromRoute] string name)
        {
            var product = _service.GetProductByName(name);
            return Ok(new
            {
                Success = true,
                Message = "Product retrieved successfully",
                Data = product
            });
        }

        [HttpGet("price/descending")]
        public IActionResult GetProductByPriceDescending()
        {
            var products = _service.GetProductsByPriceDescending();
            return Ok(new
            {
                Success = true,
                Message = "Products retrieved successfully",
                Data = products
            });
        }

        [HttpGet("price/ascending")]
        public IActionResult GetProductByPriceAscending()
        {
            var products = _service.GetProductsByPriceAscending();
            return Ok(new
            {
                Success = true,
                Message = "Products retrieved successfully",
                Data = products
            });
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _service.GetAllProducts();
            return Ok(new
            {
                Success = true,
                Message = "Products retrieved successfully",
                Data = products
            });
        }
    }
}

