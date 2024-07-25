using Newtonsoft.Json;

namespace StallosDotnetPleno.Domain.Models.Roster
{
    public class RosterCepim
    {
        [JsonProperty(nameof(Id))]
        public string? Id { get; set; }

        [JsonProperty("Nome")]
        public string? Name { get; set; }

        [JsonProperty(nameof(CNPJ))]
        public string? CNPJ { get; set; }
        [JsonProperty("MotivoImpedimento")]
        public string? Reason { get; set; }
        [JsonProperty("OrgaoConcedente")]
        public string? GrantingBody { get; set; }
        [JsonProperty("NumeroConvenio")]
        public string? AgreementNumber { get; set; }
    }
}