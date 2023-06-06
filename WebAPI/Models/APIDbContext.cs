using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace WebAPI.Models
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options)
        {
           //Database.EnsureCreated();
        }        
        public DbSet<Produk> Produks { get; set; }

    }
}
