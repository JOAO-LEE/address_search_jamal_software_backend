using AddressSearch.DTOs;
using AddressSearch.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AddressSearch.Services;

public class AddressService
{
    private readonly IMongoCollection<Address> _address;

    public AddressService(IOptions<AddressSearchDatabaseSettings> AddressSearchDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            AddressSearchDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            AddressSearchDatabaseSettings.Value.DatabaseName);

        _address = mongoDatabase.GetCollection<Address>(
            AddressSearchDatabaseSettings.Value.CollectionName);
    }

    public async Task<List<Address>> GetAllAddresses() 
    {
        var allAddressesFound = await _address.Find(_ => true).ToListAsync().ConfigureAwait(false);
        return allAddressesFound;
    }

    public async Task<Address> GetAddressByCepNumber(string cepNumber) 
    {
        var foundAddress = await _address.Find(x => x.Cep == cepNumber).FirstOrDefaultAsync().ConfigureAwait(false);
        return foundAddress;
    }

    public async Task CreateAddress(Address newAddress)  
    {
        await _address.InsertOneAsync(newAddress).ConfigureAwait(false);
    }
}