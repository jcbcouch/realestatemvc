using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using realestatemvc.Areas.Auth.Models;
using realestatemvc.Data;
using realestatemvc.Models;
using realestatemvc.Services;

namespace realestatemvc.Areas.Guest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IListingService _listingService;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(IListingService listingService, UserManager<ApplicationUser> userManager)
        {
            _listingService = listingService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            List<Listing> listings = _listingService.GetAllListings().ToList();
            return View(listings);
        }


        public async Task<IActionResult> SingleListing(int listingId)
        {
            if (listingId == 0)
            {
                return BadRequest();
            }
            Listing listing = await _listingService.GetListing(listingId);
            if (listing == null)
            {
                return NotFound();
            }
            return View(listing);
        }


        public async Task<IActionResult> About()
        {
            var users = await _userManager.GetUsersInRoleAsync(SD.Realtor);
            var three = users.Take(3);
            return View(three);
        }
    }
}
