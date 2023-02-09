using Microsoft.AspNetCore.Mvc;

namespace FoodForgers.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {
        [Area("Customer")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
