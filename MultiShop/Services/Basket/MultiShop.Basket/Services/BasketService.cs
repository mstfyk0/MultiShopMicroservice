using Microsoft.AspNetCore.Authentication;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.Services.LoginServices;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {

        private readonly RedisService _redisService;
        private readonly ILoginService _loginService;


        public BasketService(RedisService redisService, ILoginService loginService)
        {
            _redisService = redisService;
            _loginService = loginService;
        }

        public async Task DeleteBasket(string userId)
        {
            await _redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDto> GetBasket(string userId)
        {
            var existBasket =  await _redisService.GetDb().StringGetAsync(userId);
            return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {

            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId
                , JsonSerializer.Serialize(basketTotalDto)); 
        }
    }
}
