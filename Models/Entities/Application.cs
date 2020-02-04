using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models.Entities
{
    public class Application
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<ApplicationResourceMap> ApplicationResourceMaps { get; set; }
    }
}