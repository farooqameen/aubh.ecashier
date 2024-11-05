using System.Text.Json.Serialization;

namespace eCashier.Ottu
{
    public class PaymentRequest
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("pg_codes")]
        public List<string> PgCodes { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonPropertyName("customer_phone")]
        public string CustomerPhone { get; set; }
    }
}
