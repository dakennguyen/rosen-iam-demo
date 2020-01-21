using Demo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<UserApplicationMap> UserApplicationMap { get; set; }
    }

}