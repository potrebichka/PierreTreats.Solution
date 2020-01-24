using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PierreSweets.Models
{
    public class PierreSweetsContext : IdentityDbContext<ApplicationUser>
    {
        // public virtual DbSet<Category> Categories {get;set;}
        // public DbSet<Item> Items {get;set;}
        // public DbSet<CategoryItem> CategoryItem { get; set; }
        public PierreSweetsContext(DbContextOptions options) : base(options) {}
    }
}