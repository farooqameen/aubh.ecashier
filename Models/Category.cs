namespace eCashier.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Collection navigation
        public ICollection<Item> Items { get; } = [];
    }
}
