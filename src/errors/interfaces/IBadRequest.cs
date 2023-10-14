namespace AddressSearch.Errors;
public interface IBadRequest {
    public string Name { get; set; }
    public string Message { get; set; }
    public bool Response { get; set; }
    public int StatusCode { get; set; } 
}