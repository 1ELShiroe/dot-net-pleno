namespace StallosDotnetPleno.Api.UseCases.Customer.GetCustomer
{
    public record GetCustomerResponse(string Message, GetCustomerDataResponse Data);
    public record GetCustomerDataResponse(ResponseGetCustomerData Customer, string Token);
    public record ResponseGetCustomerData(int Id, string TipoPessoa, string Nome, string Documento, ResponseGetCustomerAddress[] Enderecos, string[] Listas);
    public record ResponseGetCustomerAddress(string CEP, string Logradouro, string Bairro, string Cidade, string UF);
}