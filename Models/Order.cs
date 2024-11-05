using System.ComponentModel.DataAnnotations;

namespace eCashier.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; } // required foreign key
        public Customer Customer { get; set; } = null!; // required reference
        public int Reference { get; set; }

        [Display(Name = "Expiry Date")]
        public DateTime? ExpiryDate { get; set; }

        [Display(Name = "Internal Note")]
        public string InternalNote { get; set; }
        public List<Item> Items { get; } = [];
    }
}
