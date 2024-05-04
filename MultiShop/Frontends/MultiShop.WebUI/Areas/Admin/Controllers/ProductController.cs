using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{

    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7047/api/products/getAllProduct");


            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {

            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Ekle";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7047/api/categories/getAllCategory");

            var jsonData= await responseMessage.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            List<SelectListItem> categorySelectList = (from c in values
                                                       select new SelectListItem    
                                                       {
                                                           Text=c.CategoryName,
                                                           Value=c.CategoryId
                                                       }).ToList();

            ViewBag.CategoryValues = categorySelectList;
            return View();
        }

        [HttpPost]
        [Route("createProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsMessage = await client.PostAsync("https://localhost:7047/api/products/createProduct", content);

            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });

            }

            return View();
        }

        [Route("deleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {

            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.DeleteAsync("https://localhost:7047/api/products/deleteProduct/" + id);

            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });

            }

            return View();
        }



        [Route("updateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Güncelleme";




            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:7047/api/products/getProductById/" + id);

            var responseMessageCategory = await client.GetAsync("https://localhost:7047/api/categories/getAllCategory");

            var jsonDataCategory = await responseMessageCategory.Content.ReadAsStringAsync();

            var valuesCategory = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonDataCategory);

            List<SelectListItem> categorySelectList = (from c in valuesCategory
                                                       select new SelectListItem
                                                       {
                                                           Text = c.CategoryName,
                                                           Value = c.CategoryId
                                                       }).ToList();

            ViewBag.CategoryValues = categorySelectList;


            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                return View(values);
            }

            return View();
        }


        [HttpPost]
        [Route("updateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsMessage = await client.PutAsync("https://localhost:7047/api/products/updateProduct", content);

            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });

            }
            return View();
        }

    }
}
