using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Services.FeatureServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {

        private readonly IFeatureService _featureService;

        public FeaturesController(IFeatureService Featureervice)
        {
            _featureService = Featureervice;
        }

        [HttpGet("getAllFeature")]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _featureService.GetAllFeatureAsync();
            return Ok(values);
        }

        [HttpGet("getFeatureById/{id}")]
        public async Task<IActionResult> GetFeatureById([FromRoute] string id)
        {
            var values = await _featureService.GetByIdFeatureAsync(id);
            return Ok(values);
        }

        [HttpPost("createFeature")]
        public async Task<IActionResult> CreateFeature([FromBody] CreateFeatureDto createFeatureDto)
        {
            await _featureService.CreateFeatureAsync(createFeatureDto);
            return Ok("Öne çıkan alan başarıyla eklendi.");
        }

        [HttpDelete("deleteFeature/{id}")]
        public async Task<IActionResult> DeteleFeature([FromRoute] string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return Ok("Öne çıkan alan başarıyla silindi.");
        }

        [HttpPut("updateFeature")]
        public async Task<IActionResult> UpdateFeature([FromBody] UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.UpdateFeatureAsync(updateFeatureDto);
            return Ok("Öne çıkan alan başarıyla güncellendi.");
        }
    }
}
