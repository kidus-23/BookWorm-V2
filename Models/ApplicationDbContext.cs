using BookWorm.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWorm.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<CoverPage> CoverPages { get; set; }

    }
}
