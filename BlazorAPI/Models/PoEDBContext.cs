using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Models
{
    public class PoEDBContext : DbContext
    {
        public PoEDBContext(DbContextOptions<PoEDBContext> options) 
            : base(options)
        {
        }

        public DbSet<DivinationCard> DivinationCard { get; set; }
        public DbSet<TestModel> TestModel { get; set; }
    }
}
