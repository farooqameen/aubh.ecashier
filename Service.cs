using System.ComponentModel.DataAnnotations;

namespace aubh.ecashier
{
    public class Service
    {
        public int Id { get; set; }

        public ServiceEnum Options { get; set; }
    }

    public enum ServiceEnum
    {
        [Display(Name = "Accomodation Fees")]
        Accomodation,

        [Display(Name = "Books")]
        Books,

        [Display(Name = "Late Payment Fee")]
        LatePaymentFee,
    }
}
