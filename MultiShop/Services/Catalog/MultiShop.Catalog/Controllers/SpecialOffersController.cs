using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly ISpecialOfferService _SpecialOfferService;

        public SpecialOffersController(ISpecialOfferService SpecialOfferService)
        {
            _SpecialOfferService = SpecialOfferService;
        }

        [HttpGet("getAllSpecialOffer")]
        public async Task<IActionResult> SpecialOfferList()
        {
            var values = await _SpecialOfferService.GetAllSpecialOfferAsync();
            return Ok(values);
        }

        [HttpGet("getSpecialOfferById/{id}")]
        public async Task<IActionResult> GetSpecialOfferById([FromRoute] string id)
        {
            var values = await _SpecialOfferService.GetByIdSpecialOfferAsync(id);
            return Ok(values);
        }

        [HttpPost("createSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer([FromBody] CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _SpecialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return Ok("Özel teklif başarıyla eklendi.");
        }

        [HttpDelete("deleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeteleSpecialOffer([FromRoute] string id)
        {
            await _SpecialOfferService.DeleteSpecialOfferAsync(id);
            return Ok("Özel teklif başarıyla silindi.");
        }

        [HttpPut("updateSpecialOffer")]
        public async Task<IActionResult> UpdateSpecialOffer([FromBody] UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _SpecialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return Ok("Özel teklif başarıyla güncellendi.");
        }

    }
}
