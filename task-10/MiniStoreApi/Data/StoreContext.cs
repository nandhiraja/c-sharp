using Microsoft.EntityFrameworkCore;
using MiniStoreApi.Models;

namespace MiniStoreApi.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
    }
}
