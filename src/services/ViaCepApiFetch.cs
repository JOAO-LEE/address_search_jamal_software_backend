using AddressSearch.Models;
using Services.ViaCepServiceInterfaces;

namespace AddressSearch.Services {
    public class ViaCepService : IViaCepService
    {
       private readonly string _viaCepBaseAddress = "https://viacep.com.br/ws/";
        public ViaCepService(HttpClient client) 
        {
            _client = client;
        }

        public async Task<string> GetAddress(string cepNumber)
        { 
            try
            {
                
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
