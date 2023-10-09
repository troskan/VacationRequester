using Microsoft.EntityFrameworkCore;
using VacationRequester.Models;

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

        public DbSet<User> Users { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
    }
}
