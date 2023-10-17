namespace AddressSearch.DTOs;

public record class AddressDto(
    string Id,
    string Cep,
    string Logradouro,
    string Complemento,
    string Bairro,
    string Localidade,
    string Uf,
    int Ibge,
    string Gia,
    int Ddd,
    string Siafi
);