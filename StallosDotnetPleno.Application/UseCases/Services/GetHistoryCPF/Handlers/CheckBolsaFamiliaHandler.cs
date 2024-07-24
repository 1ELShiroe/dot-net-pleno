namespace StallosDotnetPleno.Application.UseCases.Services.GetHistoryCPF.Handlers
{
    public class CheckBolsaFamiliaHandler : Handler<GetHistoryCPFUCRequest>
    {
        public override void ProcessRequest(GetHistoryCPFUCRequest req)
        {
            req.Process(HandlerName, "Starting to process request to search bolsa familia with CPF");

            // Ainda a realizar implementação dos metodos pra acesso a API, aguardado acesso a API pra testes.

            Successor?.ProcessRequest(req);
        }
    }
}