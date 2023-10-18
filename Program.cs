using System.Net;
using AddressSearch.Models;
using AddressSearch.Services;
using Services.ViaCepServiceInterfaces;
using Providers.Interfaces;
using Providers;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.Configure<AddressSearchDatabaseSettings>(builder.Configuration.GetSection("AddressSearchDatabase"));
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins, policy =>
    {
        policy.AllowAnyOrigin() // Ou use .WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddSingleton<AddressService>();
// builder.Services.AddSingleton<IHttpClientMicrosoft, HttpClientMicrosoft>();
// builder.Services.AddSingleton<IViaCepService, ViaCepService>();

var app = builder.Build();

app.MapGet("/", async (AddressService addressService) =>
{
    try
    {
        var foundAddressInDB = await addressService.GetAllAddresses();
        return Results.Ok(foundAddressInDB);
    }
    catch (RequestException ex)
    {
        return ex.StatusCode switch
        {
            HttpStatusCode.NotFound => Results.NotFound(new { ex.Message, ex.StatusCode, severity = ex.Severity  }),
            _ => Results.BadRequest(ex.Message),
        };
    }
});

// app.MapGet("/{cepNumber}", async (string cepNumber, AddressService addressService, ViaCepService cepService) =>
// {

//     var foundAddressInDB = await addressService.GetAddressByCepNumber(cepNumber);
//     if (foundAddressInDB is not null)
//     {
//         return Results.Ok(foundAddressInDB);
//     }

//     var foundAddressExternal = await cepService.GetAddress(cepNumber);
//     if (foundAddressExternal is null)
//     {
//         return Results.BadRequest(new { message = "Não existe endereços com o CEP informado!", name = "error" });
//     }
//     await addressService.CreateAddress(foundAddressExternal);
//     return Results.Ok(foundAddressExternal);
// });

app.UseCors(MyAllowSpecificOrigins);

app.Run();