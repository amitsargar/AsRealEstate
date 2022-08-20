using System.Data.Entity;

namespace AsRealEstate2.Models
{
    public class AsRealEstateDbContext : DbContext
    {
        public AsRealEstateDbContext()
        {

        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PropertyMode> PropertyModes { get; set; }
        public DbSet<State> States { get; set; }
    }
}