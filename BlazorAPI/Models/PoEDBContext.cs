using BlazorAPI.Models.BlazorApp2.Data.Models;
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
        public DbSet<CurrencyReference> CurrencyReferences { get; set; }

        public DbSet<Currency> Currency { get; set; }
    }
}
