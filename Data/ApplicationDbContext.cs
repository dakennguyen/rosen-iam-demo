using Demo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ROSEN-IAM-Demo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public DbSet<User> User { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<UserApplicationMap> UserApplicationMap { get; set; }
    }

}