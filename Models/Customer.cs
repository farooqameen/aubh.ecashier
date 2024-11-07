using System.ComponentModel.DataAnnotations;

namespace eCashier.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Student ID")]
        public string StudentId { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string Telephone { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        // Collection navigation
        public ICollection<Order> Orders { get; } = [];
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
