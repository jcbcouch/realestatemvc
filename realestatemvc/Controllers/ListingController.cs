using Microsoft.AspNetCore.Mvc;

namespace realestatemvc.Controllers
{
    public class ListingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
