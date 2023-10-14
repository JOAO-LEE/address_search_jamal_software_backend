using AddressSearch.Models;
using Services.ViaCepServiceInterfaces;

namespace AddressSearch.Services {
    public class ViaCepService : IViaCepService
    {
        public HttpClient _client;
         
        public ViaCepService(HttpClient client) {
            _client = client;
        }

        public async Task<Address> GetAddress(string cepNumber)
        { 
            string ViaCepUrl = $"https://viacep.com.br/ws/{cepNumber}/json"; 
           var requestMessage = new HttpRequestMessage(HttpMethod.Get, ViaCepUrl);
           requestMessage.Headers.Add("Accept", "application/json");
            var response = await _client.SendAsync(requestMessage).ConfigureAwait(false);
            var wasRequestSuccesful = !response.IsSuccessStatusCode;
            if (wasRequestSuccesful)
            {
                return null!;
            }

            var jsonResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (jsonResponse.Contains("\"erro\": true"))
            {
            return null!;
            }

            var result = await response.Content.ReadFromJsonAsync<Address>().ConfigureAwait(false);
            return result!;
        }
    }
}
