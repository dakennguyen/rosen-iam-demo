using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models.Entities
{
    public class UserRoleMap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}