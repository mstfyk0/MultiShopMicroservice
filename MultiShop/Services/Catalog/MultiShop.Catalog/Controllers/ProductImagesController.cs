using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet("productImageDetailList")]
        public async Task<IActionResult> ProductImageDetailList()
        {
            var values = await _productImageService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("getProductImageById/{id}")]
        public async Task<IActionResult> GetProductImageById([FromRoute] string id)
        {
            var values = await _productImageService.GetByIdProductImageAsync(id);
            return Ok(values);
        }
        [HttpGet("getByProductIdProductImages/{id}")]
        public async Task<IActionResult> GetProductIdProductImages([FromRoute] string id)
        {
            var values = await _productImageService.GetByProductIdProductImageAsync(id);
            return Ok(values);
        }

        [HttpPost("createProductImage")]
        public async Task<IActionResult> CreateProductImage([FromBody] CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Ürün görselleri başarıyla eklendi.");
        }

        [HttpDelete("deteleProductImage/{id}")]
        public async Task<IActionResult> DeteleProductImage([FromRoute] string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok("Ürün görselleri başarıyla silindi.");
        }

        [HttpPut("updateProductImage")]
        public async Task<IActionResult> UpdateProductImage([FromBody] UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Ürün görselleri başarıyla güncellendi.");
        }
    }
}
