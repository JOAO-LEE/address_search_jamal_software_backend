using AddressSearch.Models;
using Services.ViaCepServiceInterfaces;

namespace AddressSearch.Services {
    public class ViaCepService : IViaCepService
    {
        private readonly HttpClient _client;
        private readonly string viaCepBaseAddress = "https://viacep.com.br/ws/";
        public ViaCepService(HttpClient client) 
        {
            _client = client;
        }

        public async Task<string> GetAddress(string cepNumber)
        { 
            try
            {
                string ViaCepUrl = $"{viaCepBaseAddress}{cepNumber}/json"; 
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, ViaCepUrl);
            }
            catch (Exception err)
            {
                
                throw;
            }
        //    requestMessage.Headers.Add("Accept", "application/json");
        //     var response = await _client.SendAsync(requestMessage).ConfigureAwait(false);
        //     var wasRequestSuccesful = !response.IsSuccessStatusCode;
        //     if (wasRequestSuccesful)
        //     {
        //         return null!;
        //     }

        //     var jsonResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        //     if (jsonResponse.Contains("\"erro\": true"))
        //     {
        //     return null!;
        //     }

        //     var result = await response.Content.ReadFromJsonAsync<Address>().ConfigureAwait(false);
        //     return result!;
        }
    }
}
