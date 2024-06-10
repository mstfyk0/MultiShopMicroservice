using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    [Route("ProductList/")]
    public class ProductListController : Controller
    {
        
        public IActionResult Index(string id)
        {
            ViewBag.i = id;
            return  View();
        }
        [Route("ProductDetail/{id}")]
        public IActionResult ProductDetail([FromRoute]string id )
        {
            ViewBag.x = id;
            return View();
        }
    }
}
