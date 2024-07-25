namespace StallosDotnetPleno.Api.UseCases.Customer.AddCustomer
{
    public record AddCustomerResponse(string Message, AddCustomerDataResponse Data);
    public record AddCustomerDataResponse(int Id, string TipoPessoa, string Nome, string Documento, AddCustomerAddressResponse[] Enderecos, string[] Listas);
    public record AddCustomerAddressResponse(string CEP, string Logradouro, string Bairro, string Cidade, string UF);
}