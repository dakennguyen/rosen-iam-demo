using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models.Entities
{
    public class UserApplicationMap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}