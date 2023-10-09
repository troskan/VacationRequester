using Microsoft.EntityFrameworkCore;

namespace VacationRequester.Data
{
    public class AppDbContext : DbContext
    {
        //DbSet here
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
