using Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace Entities.DataContext
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext() { }

        public WebApiDbContext(DbContextOptions<WebApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseInMemoryDatabase("Patterns_DB");
        }
    }
}
