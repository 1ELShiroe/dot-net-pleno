namespace StallosDotnetPleno.Application.UseCases.Services.GetHistoryCNPJ.Handlers
{
    public class CheckOfacHandler : Handler<GetHistoryCNPJUCRequest>
    {
        public override void ProcessRequest(GetHistoryCNPJUCRequest req)
        {
            req.Process(HandlerName, "Starting to process request to search Ofac with CNPJ");

            // Ainda a realizar implementação dos metodos pra acesso a API, aguardado acesso a API pra testes.

            Successor?.ProcessRequest(req);
        }
    }
}