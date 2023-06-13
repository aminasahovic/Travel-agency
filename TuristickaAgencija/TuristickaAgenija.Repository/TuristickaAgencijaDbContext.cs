using Core.TuristickaAgencija.Models;
using Microsoft.EntityFrameworkCore;

namespace TuristickaAgenija.Repository
{
    public class TuristickaAgencijaDbContext: DbContext
    {
        public TuristickaAgencijaDbContext(DbContextOptions<TuristickaAgencijaDbContext> opcije):base (opcije)
        {

        }

        public DbSet<User> Korisnici { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Destination> Destination { get; set; }
        public DbSet<Accommodation> Accommodation { get; set; }
        public DbSet<Transportation> Transportation { get; set; }
        public DbSet<TravelArrangement> TravelArrangement { get; set; }
        public DbSet<Counter> Counter { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Office> Office { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Motel> Motel { get; set; }
        public DbSet<DestinationImage> DestinationImage { get; set; }
        public DbSet<AccommodationImage> AccommodationImage { get; set; }


    }
}