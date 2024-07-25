namespace StallosDotnetPleno.Api.UseCases.Customer.GetCustomer
{
    public record GetCustomerResponse(string Message, GetCustomerDataResponse Data);
    public record GetCustomerDataResponse(int Id, string TipoPessoa, string Nome, string Documento, GetCustomerAddressResponse[] Enderecos, string[] Listas);
    public record GetCustomerAddressResponse(string CEP, string Logradouro, string Bairro, string Cidade, string UF);
}