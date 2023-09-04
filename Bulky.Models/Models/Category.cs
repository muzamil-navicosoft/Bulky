using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public ICollection<Category>? Categories { get; set;}
    }
}
