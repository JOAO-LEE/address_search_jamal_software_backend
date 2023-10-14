using System.Net;
using Providers.Interfaces;

public class HttpClientMicrosoft: IHttpClient<string> 
{   
    
    private readonly HttpClient _client;
    public HttpClientMicrosoft(HttpClient client) 
    {
        _client = client;
    }

    public async Task<string> Get(string url)
    {   
        try
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            requestMessage.Headers.Add("Accept", "application/json");
            var response = await _client.SendAsync(requestMessage).ConfigureAwait(false);
            bool wasRequestSuccesful = response.StatusCode == HttpStatusCode.BadRequest || !response.IsSuccessStatusCode;
            if (wasRequestSuccesful) 
            {
                throw new Exception(response.Content.ToString());
            }
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        } 
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}