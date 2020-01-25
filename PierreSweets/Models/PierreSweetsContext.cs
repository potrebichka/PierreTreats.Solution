using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PierreSweets.Models
{
    public class PierreSweetsContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Treat> Treats {get;set;}
        public DbSet<Flavor> Flavors {get;set;}
        public DbSet<Order> Orders {get;set;}
        public DbSet<TreatFlavor> TreatFlavor { get; set; }
        public PierreSweetsContext(DbContextOptions options) : base(options) {}
    }
}