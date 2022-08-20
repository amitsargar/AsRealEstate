using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AsRealEstate2.Models
{
    public class AsRealEstateDbContext : DbContext
    {
        public AsRealEstateDbContext()
        {

        }
        public DbSet<Role> Roles { get; set; }
    }
}