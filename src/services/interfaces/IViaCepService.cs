using AddressSearch.DTOs;
using AddressSearch.Models;

namespace Services.ViaCepServiceInterfaces 
{
    public interface IViaCepService 
    {
        Task<string> GetAddress(string cepNumber);
    }
}
