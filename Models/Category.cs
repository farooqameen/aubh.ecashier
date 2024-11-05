using System.ComponentModel.DataAnnotations;

namespace eCashier.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // Collection navigation
        public ICollection<Item> Items { get; } = [];
    }
}
