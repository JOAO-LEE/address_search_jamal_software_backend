namespace Providers.Interfaces;

public interface IHttpClientMicrosoft : IHttpClient<string>
{
    Task<string> Get();
}