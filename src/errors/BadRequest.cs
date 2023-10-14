using AddressSearch.Errors;

public class BadRequest: Exception
{
    public string Name { get; set; }
    public string Message { get; set; }
    public bool Response { get; set; }
    public int StatusCode { get; set; }

    public BadRequest(string ex, IBadRequest innerException) : base(ex)
    {
        Name = innerException.Name;
        Message = ex;
        Response = true;
        StatusCode = innerException.StatusCode;
    }
}