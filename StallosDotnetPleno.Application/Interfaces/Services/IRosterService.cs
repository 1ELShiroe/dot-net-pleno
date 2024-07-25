using StallosDotnetPleno.Domain.Models.Roster;

namespace StallosDotnetPleno.Application.Interfaces.Services
{
    public interface IRosterService
    {
        public Task<string> GetTokenAsync();
        public Task<string> GetProtocol(string name, string document, string responsible, int origin, string[] histories);
        public Task<RosterDefault<RosterBolsaFamilia>> BolsaFamilia(string protocol, string? comparison, string name, string cpf, int? pageNumber = 1, int? pageSize = 10);
        public Task<RosterDefault<RosterPep>> Pep(string protocol, string? comparison, string name, string cpf, int? pageNumber = 1, int? pageSize = 10);
        public Task<RosterDefault<RosterInterpol>> Interpol(string protocol, string? comparison, string name, int? pageNumber = 1, int? pageSize = 10);
        public Task<RosterDefault<RosterOFac>> OFac(string protocol, string? comparison, string name, int? pageNumber = 1, int? pageSize = 10);
        public Task<RosterDefault<RosterCepim>> Cepim(string protocol, string? comparison, string name, int? pageNumber = 1, int? pageSize = 10);
    }
}