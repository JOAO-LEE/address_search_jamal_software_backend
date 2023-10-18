using AddressSearch.Models;
using AddressSearch.Models.Interfaces;

namespace Services.ViaCepServiceInterfaces
{
    public interface IViaCepService
    {
        Task<Address> GetAddress(string cepNumber);
    }
}
