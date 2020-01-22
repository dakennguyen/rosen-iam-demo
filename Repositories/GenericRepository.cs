using System.Linq;
using Demo.Data;
using Demo.Models.Entities;

namespace Demo.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Get();
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<T> Get() => this.context.Set<T>();
    }
}