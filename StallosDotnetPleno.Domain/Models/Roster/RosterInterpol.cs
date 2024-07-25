using Newtonsoft.Json;

namespace StallosDotnetPleno.Domain.Models.Roster
{
    public class RosterInterpol
    {
        [JsonProperty(nameof(Id))]
        public string? Id { get; set; }

        [JsonProperty("IdInterpol")]
        public string? InterpolId { get; set; }

        [JsonProperty("PrimeiroNome")]
        public string? FirstName { get; set; }

        [JsonProperty("Sobrenome")]
        public string? LastName { get; set; }

        [JsonProperty("NomeCompleto")]
        public string? FullName { get; set; }

        [JsonProperty("Genero")]
        public string? Gender { get; set; }

        [JsonProperty("DataNascimento")]
        public string? BirthDate { get; set; }

        [JsonProperty("Nacionalidades")]
        public string[] Nationalities { get; set; } = [];
    }
}