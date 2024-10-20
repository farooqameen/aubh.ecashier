namespace eCashier.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; } // required foreign key
        public Customer Customer { get; set; } = null!; // required reference
        public int Reference { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string InternalNote { get; set; }
        public List<Item> Items { get; } = [];
    }
}
