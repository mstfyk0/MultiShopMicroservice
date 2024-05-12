using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Services.AboutServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutsController(IAboutService AboutService)
        {
            _aboutService = AboutService;
        }

        [HttpGet("getAllAbout")]
        public async Task<IActionResult> AboutList()
        {
            var values = await _aboutService.GetAllAboutAsync();
            return Ok(values);
        }

        [HttpGet("getAboutById/{id}")]
        public async Task<IActionResult> GetAboutById([FromRoute] string id)
        {
            var values = await _aboutService.GetByIdAboutAsync(id);
            return Ok(values);
        }

        [HttpPost("createAbout")]
        public async Task<IActionResult> CreateAbout([FromBody] CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAboutAsync(createAboutDto);
            return Ok("Hakkımda başarıyla eklendi.");
        }

        [HttpDelete("deleteAbout/{id}")]
        public async Task<IActionResult> DeteleAbout([FromRoute] string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return Ok("Hakkımda başarıyla silindi.");
        }

        [HttpPut("updateAbout")]
        public async Task<IActionResult> UpdateAbout([FromBody] UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAboutAsync(updateAboutDto);
            return Ok("Hakkımda başarıyla güncellendi.");
        }
    }
}
