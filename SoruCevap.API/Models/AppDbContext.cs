using Microsoft.EntityFrameworkCore;

namespace SoruCevap.API.Models
{
    public class AppDbContext : DbContext
    {
        DbSet<Questions> Questions { get; set; }
        DbSet<Answer> Answers { get; set; }

        DbSet<Label> Labels { get; set; }

        DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
