using Microsoft.EntityFrameworkCore;
using Bacana.Models;

namespace Bacana.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Post> Produtos { get; set; }
        public DbSet<User> Comentarios { get; set; }
    }
}
