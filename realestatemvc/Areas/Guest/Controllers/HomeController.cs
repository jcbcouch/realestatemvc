using Microsoft.AspNetCore.Mvc;
using realestatemvc.Data;
using realestatemvc.Models;
using realestatemvc.Services;

namespace realestatemvc.Areas.Guest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IListingService _listingService;
        public HomeController(IListingService listingService)
        {
            _listingService = listingService;
        }
        public async Task<IActionResult> Index()
        {
            List<Listing> listings = _listingService.GetAllListings().ToList();
            return View(listings);
        }
    }
}
