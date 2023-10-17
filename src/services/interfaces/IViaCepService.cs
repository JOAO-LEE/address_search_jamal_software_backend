using AddressSearch.DTOs;

namespace Services.ViaCepServiceInterfaces
{
    public interface IViaCepService<T>
    {
        Task<T> GetAddress(string cepNumber);
    }
}
