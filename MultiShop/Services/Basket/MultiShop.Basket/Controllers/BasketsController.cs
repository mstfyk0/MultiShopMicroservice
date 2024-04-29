﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.Services;
using MultiShop.Basket.Services.LoginServices;
using System.Text.Json.Serialization;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketDetail()
        {
            var user = User.Claims;
            var values = await _basketService.GetBasket(_loginService.GetUserId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
        {
            //giriş yapan kullanıcının id değerini alıyorum bu sebeple dışarıdan girişe ihtiyaç bulunmuyor.
            basketTotalDto.UserId = _loginService.GetUserId;
            await _basketService.SaveBasket(basketTotalDto);
            return Ok("Sepet kaydedildi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMyBasket()
        {
           
            await _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok("Sepet silindi.");
        }

    }
}
