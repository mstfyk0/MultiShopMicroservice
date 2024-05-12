using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/Brand")]
    public class BrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            ViewBag.v0 = "Marka İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Markaler";
            ViewBag.v3 = "Marka Listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7047/api/brands/getAllBrand");


            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                return View(values);
            }

            return View();
        }


        [HttpGet]
        [Route("createBrand")]
        public IActionResult CreateBrand()
        {
            ViewBag.v0 = "Marka İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yeni Marka Girişi";
            ViewBag.v3 = "Marka İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("createBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBrandDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsMessage = await client.PostAsync("https://localhost:7047/api/brands/createBrand", content);

            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Admin" });

            }

            return View();
        }

        [Route("deleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {

            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.DeleteAsync("https://localhost:7047/api/brands/deleteBrand/" + id);

            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Admin" });

            }

            return View();
        }

        [Route("updateBrand/{id}")]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            ViewBag.v0 = "Marka İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Markaler";
            ViewBag.v3 = "Marka Güncelleme";


            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:7047/api/brands/getBrandById/" + id);


            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData);
                return View(values);
            }

            return View();
        }


        [HttpPost]
        [Route("updateBrand/{id}")]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBrandDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsMessage = await client.PutAsync("https://localhost:7047/api/brands/updateBrand", content);

            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Admin" });

            }
            return View();
        }
    }
}
