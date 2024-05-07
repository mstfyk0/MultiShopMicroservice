using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Services.FeatureSliderServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class FeatureSliderController : ControllerBase
    {
        private readonly IFeatureSliderService _FeatureSliderService;

        public FeatureSliderController(IFeatureSliderService FeatureSliderService)
        {
            _FeatureSliderService = FeatureSliderService;
        }

        [HttpGet("getAllFeatureSlider")]
        public async Task<IActionResult> FeatureSliderList()
        {
            var values = await _FeatureSliderService.GetAllFeatureSliderAsync();
            return Ok(values);
        }

        [HttpGet("getFeatureSliderById/{id}")]
        public async Task<IActionResult> GetFeatureSliderById([FromRoute] string id)
        {
            var values = await _FeatureSliderService.GetByIdFeatureSliderAsync(id);
            return Ok(values);
        }

        [HttpPost("createFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider([FromBody] CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _FeatureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return Ok("Öne çıkan görsel başarıyla eklendi.");
        }

        [HttpDelete("deleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeteleFeatureSlider([FromRoute] string id)
        {
            await _FeatureSliderService.DeleteFeatureSliderAsync(id);
            return Ok("Öne çıkan görsel başarıyla silindi.");
        }

        [HttpPut("updateFeatureSlider")]
        public async Task<IActionResult> UpdateFeatureSlider([FromBody] UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _FeatureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return Ok("Öne çıkan görsel başarıyla güncellendi.");
        }

    }
}
