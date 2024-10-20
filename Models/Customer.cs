namespace eCashier.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Notes { get; set; }

        // Collection navigation
        public ICollection<Order> Orders { get; } = [];
        public string NameFull
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
