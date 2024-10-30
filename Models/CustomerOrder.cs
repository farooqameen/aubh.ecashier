namespace eCashier.Models
{
    public class CustomerOrder
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public int ItemId { get; set; }
        public string Note { get; set; }

    }
}
