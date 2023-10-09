using AddressSearch.Models;

namespace Services.ViaCepServiceInterfaces {
public interface IViaCepService {
    Task<Address> GetAddress(string cepNumber);
}

}
