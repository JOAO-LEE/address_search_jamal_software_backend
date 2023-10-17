using Services.ViaCepServiceInterfaces;
using Providers.Interfaces;
using AddressSearch.DTOs;
using System.Text.Json;

namespace AddressSearch.Services
{
    public class ViaCepService : IViaCepService<AddressDto>
    {
        private readonly string _viaCepBaseAddress = "https://viacep.com.br/ws/";
        private readonly IHttpClientMicrosoft _client;
        public ViaCepService(IHttpClientMicrosoft client)
        {
            _client = client;
        }

        public async Task<AddressDto> GetAddress(string cepNumber)
        {
            var fullUrl = $"{_viaCepBaseAddress}/${cepNumber}/json";
            var addressResult = await _client.Get(fullUrl).ConfigureAwait(false); 
            var response = JsonSerializer.Deserialize<AddressDto>(addressResult);
            return response!;
        }
    }
}
