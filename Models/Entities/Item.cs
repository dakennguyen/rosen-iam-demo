using System.ComponentModel.DataAnnotations;

namespace Demo.Models.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int ResourceId { get; set; }
        public Resource Resource { get; set; }
    }
}