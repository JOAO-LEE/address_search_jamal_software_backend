namespace Providers.Interfaces;

public interface IHttpClientMicrosoft : IHttpClient
{
    new Task<string> Get(string url);
}