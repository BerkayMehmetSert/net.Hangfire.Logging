using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Context
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
