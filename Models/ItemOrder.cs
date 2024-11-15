namespace eCashier.Models
{
    public class ItemOrder
    {
        public int ItemID { get; set; }
        public int OrderID { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; } = 1;
        public int Subtotal
        {
            get { return (UnitPrice * Quantity); }
        }
    }
}
