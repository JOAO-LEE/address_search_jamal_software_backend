namespace Providers.Interfaces;

public interface IHttpClient 
{
    public Task<string> Get(string url);
}