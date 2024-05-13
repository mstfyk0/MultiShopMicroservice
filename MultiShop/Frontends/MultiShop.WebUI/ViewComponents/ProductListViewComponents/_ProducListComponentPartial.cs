using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProducListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProducListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7047/api/Products/getProductsOneCategoryAsync/" + id);


            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductsOneCategoryDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
