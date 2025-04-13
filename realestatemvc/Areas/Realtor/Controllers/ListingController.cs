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
                //List<IFormFile> files = new List<IFormFile>()
                //{
                //    obj.PhotoOne,
                //    obj.PhotoTwo,
                //    obj.PhotoThree,
                //    obj.PhotoFour,
                //    obj.PhotoFive,
                //    obj.PhotoSix

                //};
                //foreach (IFormFile file in files)
                //{
                //    if (file != null)
                //    {
                //        string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/homes");
                //        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                //        string filePath = Path.Combine(uploadDir, fileName);
                //        using (var fileStream = new FileStream(filePath, FileMode.Create))
                //        {
                //            file.CopyTo(fileStream);
                //        }
                //        obj.fileNames.Add(fileName);
                //    }
                //}

                if (obj.PhotoOne != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/homes");
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.PhotoOne.FileName);
                    string filePath = Path.Combine(uploadDir, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        obj.PhotoOne.CopyTo(fileStream);
                    }
                    obj.PhotoOneFileName = fileName;
                }
                if (obj.PhotoTwo != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/homes");
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.PhotoTwo.FileName);
                    string filePath = Path.Combine(uploadDir, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        obj.PhotoTwo.CopyTo(fileStream);
                    }
                    obj.PhotoTwoFileName = fileName;
                }
                if (obj.PhotoThree != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/homes");
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.PhotoThree.FileName);
                    string filePath = Path.Combine(uploadDir, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        obj.PhotoThree.CopyTo(fileStream);
                    }
                    obj.PhotoThreeFileName = fileName;
                }
                if (obj.PhotoFour != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/homes");
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.PhotoFour.FileName);
                    string filePath = Path.Combine(uploadDir, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        obj.PhotoFour.CopyTo(fileStream);
                    }
                    obj.PhotoFourFileName = fileName;
                }
                if (obj.PhotoFive != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/homes");
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.PhotoFive.FileName);
                    string filePath = Path.Combine(uploadDir, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        obj.PhotoFive.CopyTo(fileStream);
                    }
                    obj.PhotoFiveFileName = fileName;
                }
                if (obj.PhotoSix != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/homes");
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.PhotoSix.FileName);
                    string filePath = Path.Combine(uploadDir, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        obj.PhotoSix.CopyTo(fileStream);
                    }
                    obj.PhotoSixFileName = fileName;
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
                    PhotoOne = obj.PhotoOneFileName,
                    PhotoTwo = obj.PhotoTwoFileName,
                    PhotoThree = obj.PhotoThreeFileName,
                    PhotoFour = obj.PhotoFourFileName,
                    PhotoFive = obj.PhotoFiveFileName,
                    PhotoSix = obj.PhotoSixFileName,
                    Created = System.DateTime.Now
                };
                await _listingService.AddListing(listingObj);
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
