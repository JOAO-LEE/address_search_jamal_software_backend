using AddressSearch.Models;
using AddressSearch.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.Configure<AddressSearchDatabaseSettings>(builder.Configuration.GetSection("AddressSearchDatabase"));
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options => 
{
    options.AddPolicy(MyAllowSpecificOrigins, policy => {
        policy.AllowAnyOrigin() // Ou use .WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddSingleton<AddressSearchService>();
builder.Services.AddHttpClient<ViaCepService>();
builder.Services.AddSingleton<ViaCepService>();

var app = builder.Build();

app.MapGet("/", async (AddressSearchService addressSearchService) =>
{
    var foundAddressInDB = await addressSearchService.GetAllAddresses();

    if (foundAddressInDB.Count() == 0)
    {
        return Results.NotFound(new { message = "Não há endereços cadastrados!" });
    }
    return Results.Ok(foundAddressInDB);
});

app.MapGet("/{cepNumber}", async (string cepNumber, AddressSearchService addressSearchService, ViaCepService cepService) =>
{

   var foundAddressInDB = await addressSearchService.GetAddressByCepNumber(cepNumber);
    if (foundAddressInDB is not null)
    {
        return Results.Ok(foundAddressInDB);
    }

    var foundAddressExternal = await cepService.GetAddress(cepNumber);
    if (foundAddressExternal is null)
    {
        return Results.BadRequest(new { message = "Não existe endereços com o CEP informado!" });
    }

    await addressSearchService.CreateAddress(foundAddressExternal);
    return Results.Ok(foundAddressExternal);
});

app.UseCors(MyAllowSpecificOrigins);

app.Run();