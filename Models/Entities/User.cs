using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public virtual ICollection<UserApplicationMap> UserApplicationMaps { get; set; }
    }
}