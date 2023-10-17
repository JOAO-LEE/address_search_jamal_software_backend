namespace Providers.Interfaces;

public interface IHttpClient<T>
{
    public Task<T> Get(string url);
}