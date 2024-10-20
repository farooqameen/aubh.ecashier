using System.ComponentModel.DataAnnotations;

namespace eCashier.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SKU { get; set; }
        public int CategoryId { get; set; } // required foreign key
        public Category Category { get; set; } = null!; // required reference
        public int Price { get; set; }
        public int Tax { get; set; }
        [Display(Name = "Notification Emails")]
        public int NotificationEmails { get; set; }
        public string Description { get; set; }
        [Display(Name = "Allow any price")]
        public bool AllowAnyPrice { get; set; }
        public bool IsVisible { get; set; }

        public List<Order> Orders { get; } = [];
    }
}
