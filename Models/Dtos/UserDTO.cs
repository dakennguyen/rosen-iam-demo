using System.Collections.Generic;
using Demo.Models.Entities;

namespace Demo.Models.Dtos
{
    public class UserDto
    {
        public string Name { get; set; }
        public List<string> RoleNames { get; set; }
    }
}