using System.ComponentModel.DataAnnotations;

namespace Demo.Models.Entities
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}