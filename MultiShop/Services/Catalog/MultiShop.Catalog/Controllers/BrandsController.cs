using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Services.BrandServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _BrandService;

        public BrandsController(IBrandService BrandService)
        {
            _BrandService = BrandService;
        }

        [HttpGet("getAllBrand")]
        public async Task<IActionResult> BrandList()
        {
            var values = await _BrandService.GetAllBrandAsync();
            return Ok(values);
        }

        [HttpGet("getBrandById/{id}")]
        public async Task<IActionResult> GetBrandById([FromRoute] string id)
        {
            var values = await _BrandService.GetByIdBrandAsync(id);
            return Ok(values);
        }

        [HttpPost("createBrand")]
        public async Task<IActionResult> CreateBrand([FromBody] CreateBrandDto createBrandDto)
        {
            await _BrandService.CreateBrandAsync(createBrandDto);
            return Ok("Marka başarıyla eklendi.");
        }

        [HttpDelete("deleteBrand/{id}")]
        public async Task<IActionResult> DeteleBrand([FromRoute] string id)
        {
            await _BrandService.DeleteBrandAsync(id);
            return Ok("Marka başarıyla silindi.");
        }

        [HttpPut("updateBrand")]
        public async Task<IActionResult> UpdateBrand([FromBody] UpdateBrandDto updateBrandDto)
        {
            await _BrandService.UpdateBrandAsync(updateBrandDto);
            return Ok("Marka başarıyla güncellendi.");
        }
    }
}
