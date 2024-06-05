using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("updateProductDetail/{id}")]
        public async Task<IActionResult> UpdateProductDetail(string id)
        {
            ViewBag.v0 = "Ürünler";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürün işlemleri";
            ViewBag.v3 = "Ürün Güncelleme";


            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:7047/api/productdetails/getProductDetailByProductId/" + id);


            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
                return View(values);
            }

            return View();
        }


        [HttpPost]
        [Route("updateProductDetail/{id}")]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDetailDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsMessage = await client.PutAsync("https://localhost:7047/api/productdetails/updateProductDetail", content);

            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });

            }
            return View();
        }
    }
}
