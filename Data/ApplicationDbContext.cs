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
        public DbSet<Role> Role { get; set; }
        public DbSet<Resource> Resource { get; set; }
        public DbSet<UserRoleMap> UserRoleMap { get; set; }
        public DbSet<ApplicationResourceMap> ApplicationResourceMap { get; set; }
    }

}