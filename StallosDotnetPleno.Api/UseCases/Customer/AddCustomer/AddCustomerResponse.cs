namespace StallosDotnetPleno.Api.UseCases.Customer.AddCustomer
{
    public record AddCustomerResponse(string Message, AddCustomerDataResponse Data);
    public record AddCustomerDataResponse(ResponseAddCustomer Customer, string Token);
    public record ResponseAddCustomer(int Id, string TipoPessoa, string Nome, string Documento, ResponseAddCustomerAddress[] Enderecos, string[] Listas);
    public record ResponseAddCustomerAddress(string CEP, string Logradouro, string Bairro, string Cidade, string UF);
}