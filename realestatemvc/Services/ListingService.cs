using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using realestatemvc.Data;
using realestatemvc.Models;
using realestatemvc.Repository;

namespace realestatemvc.Services
{
    public interface IListingService
    {
        Task AddListing(Listing listing);
        IQueryable<Listing> GetAllListings();
        Task<Listing> GetListing(int listingId);
    }

    public class ListingService : IListingService
    {
        private ApplicationDbContext _db;
        public IRepository<Listing> _listing { get; private set; }

        public ListingService(ApplicationDbContext db)
        {
            _db = db;
            _listing = new Repository<Listing>(_db);
        }

        public async Task AddListing(Listing listing)
        {
            await _listing.Add(listing);
            await _listing.SaveChanges();
        }

        public IQueryable<Listing> GetAllListings()
        {
            IQueryable<Listing> listings = _listing.GetAll().OrderByDescending(u => u.Created).AsNoTracking();
            return listings;
        }

        public async Task<Listing> GetListing(int listingId)
        {
            Listing listing = await _listing.GetAll().Where(u => u.Id == listingId).FirstOrDefaultAsync();
            return listing;
        }
    }
}
