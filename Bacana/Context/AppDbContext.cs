using Microsoft.EntityFrameworkCore;
using Bacana.Models;

namespace Bacana.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User>? User { get; set; }
        public DbSet<Post>? Post { get; set; }
    }
}
