using System.ComponentModel;

namespace aubh.ecashier
{
    public class Service
    {
        public int Id { get; set; }

        public ServiceEnum Options { get; set; }    
    }

    public enum ServiceEnum
    {
        [Description("Accomodation Fees")]
        Accomodation,

        [Description("Books")]
        Books,

        [Description("Late Payment Fee")]
        LatePaymentFee,
    }
}
