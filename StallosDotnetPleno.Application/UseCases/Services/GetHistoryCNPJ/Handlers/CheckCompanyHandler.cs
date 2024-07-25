using StallosDotnetPleno.Application.Interfaces.Services;

namespace StallosDotnetPleno.Application.UseCases.Services.GetHistoryCNPJ.Handlers
{
    public class CheckCompanyHandler(
        IRosterService Roster) : HandlerAsync<GetHistoryCNPJUCRequest>
    {
        public override async Task ProcessRequestAsync(GetHistoryCNPJUCRequest req)
        {
            req.Process(HandlerName, "Processing request to check company histories.");

            await Task.WhenAll(
                CheckCepimAsync(req), 
                CheckOFacAsync(req));

            if (Successor != null)
                await Successor.ProcessRequestAsync(req);
        }

        private async Task CheckCepimAsync(GetHistoryCNPJUCRequest req)
        {
            var type = "cepim";

            foreach (var customer in
                req.Customers.FindAll(c => !c.Histories.Contains(type)))
            {
                var protocol = await Roster.GetProtocol(
                    customer.Name, customer.Document, $"Jacson-{type}", 2, [type]);

                var response = await Roster.Cepim(protocol, null, customer.Name);

                if (response.IsFound)
                {
                    customer.Histories.Add(type);
                }
            }
        }

        private async Task CheckOFacAsync(GetHistoryCNPJUCRequest req)
        {
            var type = "ofac";

            foreach (var customer in
                req.Customers.FindAll(c => !c.Histories.Contains(type)))
            {
                var protocol = await Roster.GetProtocol(
                    customer.Name, customer.Document, $"Jacson-{type}", 2, [type]);

                var response = await Roster.OFac(protocol, null, customer.Name);

                if (response.IsFound)
                {
                    customer.Histories.Add(type);
                }
            }
        }
    }
}