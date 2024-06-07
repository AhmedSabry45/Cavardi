using System.ComponentModel.DataAnnotations;

namespace Cavardi.Entities.Models
{
    public class Category:BaseEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }


    }
}
