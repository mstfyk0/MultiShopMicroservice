using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SpecialOfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            ViewBag.v0 = "Özel Teklif İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Özel Teklif Listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7047/api/specialOffers/getAllSpecialOffer");


            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
                return View(values);
            }

            return View();
        }


        [HttpGet]
        [Route("createSpecialOffer")]
        public IActionResult CreateSpecialOffer()
        {
            ViewBag.v0 = "Özel Teklif İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yeni Özel Teklif Girişi";
            ViewBag.v3 = "Özel Teklif İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("createSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSpecialOfferDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsMessage = await client.PostAsync("https://localhost:7047/api/specialOffers/createSpecialOffer", content);

            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });

            }

            return View();
        }

        [Route("deleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {

            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.DeleteAsync("https://localhost:7047/api/specialOffers/deleteSpecialOffer/" + id);

            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });

            }

            return View();
        }

        [Route("updateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            ViewBag.v0 = "Özel Teklif İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Özel Teklif Güncelleme";


            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:7047/api/specialOffers/getSpecialOfferById/" + id);


            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(jsonData);
                return View(values);
            }

            return View();
        }


        [HttpPost]
        [Route("updateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSpecialOfferDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsMessage = await client.PutAsync("https://localhost:7047/api/specialOffers/updateSpecialOffer", content);

            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });

            }
            return View();
        }
    }
}
