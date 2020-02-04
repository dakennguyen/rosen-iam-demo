using System.ComponentModel.DataAnnotations;

namespace Demo.Models.Entities
{
    public class ApplicationResourceMap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ApplicationId { get; set; }
        public Application Application { get; set; }

        [Required]
        public int ResourceId { get; set; }
        public Resource Resource { get; set; }
    }
}