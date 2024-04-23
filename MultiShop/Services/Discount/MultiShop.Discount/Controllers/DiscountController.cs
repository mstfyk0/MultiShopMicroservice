using Microsoft.AspNetCore.Mvc;

namespace MultiShop.Discount.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
