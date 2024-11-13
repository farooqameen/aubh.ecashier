using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace eCashier.Ottu
{
    public class PaymentResponse
    {
        [JsonPropertyName("checkout_url")]
        [Display(Name = "Checkout URL")]
        public string CheckoutUrl { get; set; }

        [JsonPropertyName("session_id")]
        public string SessionId { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("payment_type")]
        public string Type { get; set; }
    }
}
