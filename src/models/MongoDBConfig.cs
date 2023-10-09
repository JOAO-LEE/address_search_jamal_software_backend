namespace AddressSearch.Models;

public class AddressSearchDatabaseSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string AddressCollectionName { get; set; } = string.Empty;
}