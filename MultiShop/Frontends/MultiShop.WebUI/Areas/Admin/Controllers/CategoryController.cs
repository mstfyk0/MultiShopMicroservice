using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            ViewBag.v0 = "Kategori İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7047/api/categories/getAllCategory");
            

            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }

            return View();
        }


        [HttpGet]
        [Route("createCategory")]
        public IActionResult CreateCategory()
        {
            ViewBag.v0 = "Kategori İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yeni Kategori Girişi";
            ViewBag.v3 = "Kategori İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("createCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData= JsonConvert.SerializeObject(createCategoryDto);   
            StringContent content = new StringContent(jsonData, Encoding.UTF8 ,"application/json");
            var responsMessage = await client.PostAsync("https://localhost:7047/api/categories/createCategory", content);

            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Category",new {area="Admin"});

            }
            
            return View();
        }


        [Route("deleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id )
        {

            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.DeleteAsync("https://localhost:7047/api/categories/deleteCategory/"+id);

            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });

            }

            return View();
        }

        [Route("updateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            ViewBag.v0 = "Kategori İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Güncelleme sayfası ";


            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:7047/api/categories/getCategoryById/" + id);


            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData= await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }

            return View();
        }


        [HttpPost]
        [Route("updateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto   updateCategoryDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");    
            var responsMessage = await client.PutAsync("https://localhost:7047/api/categories/updateCategory", content);

            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
                
            }
            return View();
        }

    }
}
