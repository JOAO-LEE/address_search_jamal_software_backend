using System.Net;

namespace AddressSearch.Errors;
public interface IRequestException
{
    public string? Name { get; set; }
    public string Message { get; }
    public bool? Response { get; set; }
    public HttpStatusCode? StatusCode { get; set; }
}