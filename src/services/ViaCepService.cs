using Services.ViaCepServiceInterfaces;
using Providers.Interfaces;
using System.Text.Json;
using AddressSearch.Models;

namespace AddressSearch.Services
{
    public class ViaCepService : IViaCepService
    {
        private readonly string _viaCepBaseAddress = "https://viacep.com.br/ws/";
        private readonly IHttpClientMicrosoft _client;
        public ViaCepService(IHttpClientMicrosoft client)
        {
            _client = client;
        }

        public async Task<Address> GetAddress(string cepNumber)
        {
            var fullUrl = $"{_viaCepBaseAddress}/${cepNumber}/json";
            var addressResult = await _client.Get(fullUrl).ConfigureAwait(false); 
            var response = JsonSerializer.Deserialize<Address>(addressResult);
            return response!;
        }
    }
}
