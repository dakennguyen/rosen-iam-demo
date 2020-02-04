using System.Collections.Generic;
using Demo.Models.Entities;

namespace Demo.Models.Dtos
{
    public class UserDTO
    {
        public string Name { get; set; }
        public virtual ICollection<UserApplicationMap> UserApplicationMaps { get; set; }
    }
}