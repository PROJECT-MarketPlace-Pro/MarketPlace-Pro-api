using MarketPlace.Pro.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Pro.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        { }

        public DbSet<Item> Items { get; set; }
    }
}