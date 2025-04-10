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
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ApplicationDbContext _db;
        public ListingController(IListingService listingService, 
                                 IWebHostEnvironment webHostEnvironment,   
                                 ApplicationDbContext db)
        {
            _listingService = listingService;
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Listing> listings = _listingService.GetAllListings().ToList();
            return View(listings);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ListingCreateViewModel obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.PhotoMain != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/homes");
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.PhotoMain.FileName);
                    string filePath = Path.Combine(uploadDir, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        obj.PhotoMain.CopyTo(fileStream);
                    }
                    obj.PhotoMainFileName = fileName;
                }
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
                    PhotoMain = obj.PhotoMainFileName,
                    Created = System.DateTime.Now
                };
                await _listingService.AddListing(listingObj);
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
