using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using realestatemvc.Areas.Realtor.Models;
using realestatemvc.Data;
using realestatemvc.Models;
using realestatemvc.Services;

namespace realestatemvc.Areas.Realtor.Controllers
{
    public class ListingController : Controller
    {
        private readonly IListingService _listingService;
        private ApplicationDbContext _db;
        public ListingController(IListingService listingService, ApplicationDbContext db)
        {
            _listingService = listingService;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Listing obj)
        {
            if (ModelState.IsValid)
            {
                var listingObj = new Listing
                {
                    Title = obj.Title,
                    Address = obj.Address,
                    City = obj.City,
                    State = obj.State,
                    Zipcode = obj.Zipcode,
                    Description = obj.Description,
                    Price = obj.Price,
                    Bedrooms = obj.Bedrooms,
                    Garage = obj.Garage,
                    Sqft = obj.Sqft,
                    Bathrooms = obj.Bathrooms,
                    LotSize = obj.LotSize,
                    IsPublished = obj.IsPublished,
                    PhotoMain = obj.PhotoMain,
                    Created = System.DateTime.Now
                };
                _db.Listings.Add(listingObj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
