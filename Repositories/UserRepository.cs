using System.Collections.Generic;
using System.Linq;
using Demo.Data;
using Demo.Models.Dtos;
using Demo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        List<UserDTO> GetMapping();
    }
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<UserDTO> GetMapping()
        {
            return Get()
                .Include(x => x.UserApplicationMaps)
                .Select(x => new UserDTO{
                    Name = x.Name,
                    UserApplicationMaps = x.UserApplicationMaps,
                })
                .ToList();
        }
    }
}