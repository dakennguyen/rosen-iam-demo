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
        List<UserDto> GetMapping();
    }
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<UserDto> GetMapping()
        {
            return Get()
                .Include(x => x.UserRoleMaps)
                    .ThenInclude(x => x.Role)
                .Select(x => new UserDto{
                    Name = x.Name,
                    RoleNames = x.UserRoleMaps.Select(urm => urm.Role.Name).ToList(),
                })
                .ToList();
        }
    }
}