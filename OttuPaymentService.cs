using RestSharp;
using System.Text.Json.Serialization;

namespace eCashier
{
    public class OttuPaymentService
    {
        private readonly string _apiKey;
        private readonly string _baseUrl;
        private readonly RestClient _client;

        public OttuPaymentService(string baseUrl, string apiKey)
        {
            _baseUrl = baseUrl.TrimEnd('/');
            _client = new RestClient(_baseUrl);
            _apiKey = apiKey;
        }

        public async Task<PaymentResponse> CreatePaymentSessionAsync(PaymentRequest request)
        {
            var restRequest = new RestRequest("/b/checkout/v1/pymt-txn/", RestSharp.Method.Post);

            restRequest.AddHeader("Authorization", $"Api-Key {_apiKey}");
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(request);

            var response = await _client.ExecuteAsync<PaymentResponse>(restRequest);

            if (!response.IsSuccessful)
            {
                Console.WriteLine(response.ErrorMessage);

                throw new Exception($"Payment session creation failed: {response.ErrorMessage}");
            }

            return response.Data;
        }
    }

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

    public class PaymentResponse
    {
        [JsonPropertyName("checkout_url")]
        public string CheckoutUrl { get; set; }

        [JsonPropertyName("session_id")]
        public string SessiontId { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("payment_type")]
        public string Type { get; set; }
    }
}
