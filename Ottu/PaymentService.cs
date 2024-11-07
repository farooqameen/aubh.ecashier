using RestSharp;

namespace eCashier.Ottu
{
    public class PaymentService
    {
        private readonly string _apiKey;
        private readonly string _baseUrl;
        private readonly RestClient _client;

        public PaymentService(string baseUrl, string apiKey)
        {
            _baseUrl = baseUrl.TrimEnd('/');
            _client = new RestClient(_baseUrl);
            _apiKey = apiKey;
        }

        public async Task<PaymentResponse> CreatePaymentSessionAsync(PaymentRequest request)
        {
            var restRequest = new RestRequest("/b/checkout/v1/pymt-txn/", Method.Post);

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
}
