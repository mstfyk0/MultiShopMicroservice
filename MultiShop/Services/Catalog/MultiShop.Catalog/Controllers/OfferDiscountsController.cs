using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Services.OfferDiscountServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class OfferDiscountsController : ControllerBase
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public OfferDiscountsController(IOfferDiscountService OfferDiscountService)
        {
            _offerDiscountService = OfferDiscountService;
        }

        [HttpGet("getAllOfferDiscount")]
        public async Task<IActionResult> OfferDiscountList()
        {
            var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return Ok(values);
        }

        [HttpGet("getOfferDiscountById/{id}")]
        public async Task<IActionResult> GetOfferDiscountById([FromRoute] string id)
        {
            var values = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
            return Ok(values);
        }

        [HttpPost("createOfferDiscount")]
        public async Task<IActionResult> CreateOfferDiscount([FromBody] CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return Ok("Özel teklif başarıyla eklendi.");
        }

        [HttpDelete("deleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeteleOfferDiscount([FromRoute] string id)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(id);
            return Ok("Özel teklif başarıyla silindi.");
        }

        [HttpPut("updateOfferDiscount")]
        public async Task<IActionResult> UpdateOfferDiscount([FromBody] UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return Ok("Özel teklif başarıyla güncellendi.");
        }
    }
}
