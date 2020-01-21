using System.Linq;
using Demo.Data;
using Demo.Models.Entities;

namespace Demo.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> Get();
    }
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IQueryable<User> Get()
        {
            return context.Set<User>();
        }
    }
}