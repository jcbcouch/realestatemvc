using System.ComponentModel.DataAnnotations;

namespace realestatemvc.Areas.Realtor.Models
{
    public class ListingCreateViewModel
    {
        //public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zipcode { get; set; }
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Bedrooms { get; set; }
        [Required]
        public int Garage { get; set; }
        [Required]
        public int Sqft { get; set; }
        [Required]
        public double Bathrooms { get; set; }
        [Required]
        public double LotSize { get; set; }
        [Required]
        public bool IsPublished { get; set; }
        [Required]
        public IFormFile PhotoMain { get; set; }
        public IFormFile? PhotoOne { get; set; }
        public IFormFile? PhotoTwo { get; set; }
        public IFormFile? PhotoThree { get; set; }
        public IFormFile? PhotoFour { get; set; }
        public IFormFile? PhotoFive { get; set; }
        public IFormFile? PhotoSix { get; set; }
        public string? PhotoMainFileName { get; set; }

        //public List<string> fileNames = new List<string>(6);
        public string? PhotoOneFileName { get; set; }
        public string? PhotoTwoFileName { get; set; }
        public string? PhotoThreeFileName { get; set; }
        public string? PhotoFourFileName { get; set; }
        public string? PhotoFiveFileName { get; set; }
        public string? PhotoSixFileName { get; set; }

        [Required]
        public string? IdentityUserId { get; set; }
    }
}
