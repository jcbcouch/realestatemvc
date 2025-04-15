using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using realestatemvc.Areas.Auth.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace realestatemvc.Models
{
    public class Listing
    {
        public int Id { get; set; }
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
        public string PhotoMain { get; set; }
        public string? PhotoOne { get; set; }
        public string? PhotoTwo { get; set; }
        public string? PhotoThree { get; set; }
        public string? PhotoFour { get; set; }
        public string? PhotoFive { get; set; }
        public string? PhotoSix { get; set; }
        public DateTime Created { get; set; }

        [Required]
        public string? IdentityUserId { get; set; }
        [ForeignKey("IdentityUserId")]
        [ValidateNever]
        public ApplicationUser? User { get; set; }
    }
}
