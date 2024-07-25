using StallosDotnetPleno.Application.Interfaces.Services;

namespace StallosDotnetPleno.Application.UseCases.Services.GetHistoryCPF.Handlers
{
    public class CheckCustomerHandler(
        IRosterService Roster) : HandlerAsync<GetHistoryCPFUCRequest>
    {
        public override async Task ProcessRequestAsync(GetHistoryCPFUCRequest req)
        {
            req.Process(HandlerName, "Processing request to check customer histories.");

            await Task.WhenAll(CheckBolsaFamilia(req), CheckInterpolAsync(req), CheckPepAsync(req));

            Successor?.ProcessRequestAsync(req);
        }

        private async Task CheckBolsaFamilia(GetHistoryCPFUCRequest req)
        {
            foreach (var customer in
                req.Customers.FindAll(c => !c.Histories.Contains("bolsa-familia")))
            {
                var protocol = await Roster.GetProtocol(
                    customer.Name, customer.Document, "Jacson", 2, ["bolsa-familia"]);

                var response = await Roster.BolsaFamilia(
                    protocol, null, customer.Name, customer.Document);

                if (response.IsFound)
                {
                    customer.Histories.Add("bolsa-familia");
                }
            }
        }

        private async Task CheckInterpolAsync(GetHistoryCPFUCRequest req)
        {
            foreach (var customer in
                req.Customers.FindAll(c => !c.Histories.Contains("pep")))
            {
                var protocol = await Roster.GetProtocol(
                    customer.Name, customer.Document, "Jacson", 2, ["pep"]);

                var response = await Roster.Interpol(protocol, null, customer.Name);

                if (response.IsFound)
                {
                    customer.Histories.Add("pep");
                }
            }
        }

        private async Task CheckPepAsync(GetHistoryCPFUCRequest req)
        {
            foreach (var customer in
                req.Customers.FindAll(c => !c.Histories.Contains("pep")))
            {
                var protocol = await Roster.GetProtocol(
                    customer.Name, customer.Document, "Jacson", 2, ["pep"]);

                var response = await Roster.Pep(protocol, null, customer.Name, customer.Document);

                if (response.IsFound)
                {
                    customer.Histories.Add("pep");
                }
            }
        }
    }
}