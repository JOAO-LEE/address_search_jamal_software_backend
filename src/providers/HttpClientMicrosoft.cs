using System.Net;
using Providers.Interfaces;
namespace Providers;
public class HttpClientMicrosoft : IHttpClientMicrosoft
{

    private readonly HttpClient _client;
    public HttpClientMicrosoft(HttpClient client)
    {
        _client = client;
    }

    public async Task<string> Get(string url)
    {

        var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        requestMessage.Headers.Add("Accept", "application/json");
        var response = await _client.SendAsync(requestMessage).ConfigureAwait(false);
        bool wasRequestSuccesful = response == null || !response.IsSuccessStatusCode;
        if (wasRequestSuccesful)
        {
            throw new RequestException(new RequestError { Message = "Algo deu errado", Severity = "error", StatusCode = HttpStatusCode.NotFound });
        }
        var responseObj = await response!.Content.ReadAsStringAsync().ConfigureAwait(false);
        if (responseObj.ToString()!.Contains("\"erro\": true"))
        {
            throw new RequestException(new RequestError { Message = "Cep inexistente", Severity = "error", StatusCode = HttpStatusCode.BadRequest });
        }
        return responseObj;
    }
}