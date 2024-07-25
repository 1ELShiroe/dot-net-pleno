using Newtonsoft.Json;

namespace StallosDotnetPleno.Infrastructure.Services.Entities.Roster
{
    public class RosterOFac
    {
        [JsonProperty(nameof(Id))]
        public string? Id { get; set; }

        [JsonProperty("Nome")]
        public string? Name { get; set; }

        [JsonProperty(nameof(IdOFAC))]
        public string? IdOFAC { get; set; }

        [JsonProperty("Tipo")]
        public string? Type { get; set; }

        [JsonProperty("Complemento")]
        public string? Complement { get; set; }

        [JsonProperty("Enderecos")]
        public RosterOFacAddress[] Addresses { get; set; } = [];

        public class RosterOFacAddress
        {
            [JsonProperty(nameof(IdOFAC))]
            public string? IdOFAC { get; set; }

            [JsonProperty("Endereco")]
            public string? Address { get; set; }

            [JsonProperty("Cidade")]
            public string? City { get; set; }

            [JsonProperty("Pais")]
            public string? Country { get; set; }
        }
    }
}
