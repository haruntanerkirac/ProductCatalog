using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Business.Abstract;
using ProductCatalog.Entities.DTOs;
using ProductCatalog.Entities.Models;

namespace ProductCatalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IValidator<ProductCreateDto> _createValidator;

        public ProductsController(IProductService productService, IValidator<ProductCreateDto> createValidator)
        {
            _productService = productService;
            _createValidator = createValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllAsync();

            if (products is null)
                return NotFound();

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product is null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductCreateDto dto)
        {
            var result = await _createValidator.ValidateAsync(dto);

            if (!result.IsValid)
            {
                var errors = result.Errors
                    .Select(e => new { Field = e.PropertyName, Error = e.ErrorMessage });
                return BadRequest(new { Errors = errors });
            }

            //var product = new Product
            //{
            //    Name = dto.Name,
            //    Price = dto.Price,
            //    Stock = dto.Stock
            //};

            await _productService.AddAsync(dto);
            return Created();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (id != product.Id)
                return BadRequest("ID eşleşmiyor.");

            var entity = await _productService.GetByIdAsync(id);

            await _productService.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product is null)
                return NotFound($"Silinecek ürün bulunamadı (ID: {id})");

            await _productService.DeleteAsync(product);
            return NoContent();

        }
    }
}
