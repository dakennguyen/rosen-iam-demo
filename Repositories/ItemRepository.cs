using System.Collections.Generic;
using System.Linq;
using Demo.Data;
using Demo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        List<Item> GetItems(int m);
    }
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<Item> GetItems(int m)
        {
            return Get().Where(x => x.ResourceId == m).ToList();
        }
    }
}