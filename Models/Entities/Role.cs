using System.ComponentModel.DataAnnotations;

namespace Demo.Models.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}