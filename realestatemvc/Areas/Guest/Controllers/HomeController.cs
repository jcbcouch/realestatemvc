using Microsoft.AspNetCore.Mvc;

namespace realestatemvc.Areas.Guest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
