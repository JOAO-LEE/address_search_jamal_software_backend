using System.Net;
using AddressSearch.Errors;

public class RequestException : Exception, IRequestException
{
    public string? Name { get; set; }
    public bool? Response { get; set; }
    public HttpStatusCode? StatusCode { get; set; }
    public override string Message {get;}

    public RequestException(IRequestError ex)
    {
        Name = ex.Name;
        Response = true;
        StatusCode = ex.StatusCode;
        Message = ex.Message!;
    }
}