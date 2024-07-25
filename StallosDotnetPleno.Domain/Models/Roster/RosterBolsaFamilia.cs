using Newtonsoft.Json;

namespace StallosDotnetPleno.Domain.Models.Roster
{
    public class RosterBolsaFamilia
    {
        [JsonProperty(nameof(Id))]
        public string? Id { get; set; }

        [JsonProperty("Referencia")]
        public string? Reference { get; set; }

        [JsonProperty(nameof(UF))]
        public string? UF { get; set; }
        [JsonProperty("Municipio")]
        public string? City { get; set; }
        [JsonProperty(nameof(Siafi))]
        public string? Siafi { get; set; }
        [JsonProperty(nameof(NIS))]
        public int NIS { get; set; }

        [JsonProperty(nameof(CPF))]
        public string? CPF { get; set; }
        [JsonProperty("Competencia")]
        public string? Competence { get; set; }
        [JsonProperty("Favorecido")]
        public string? Favored { get; set; }
        [JsonProperty("Parcela")]
        public string? Portion { get; set; }
        [JsonProperty("UltimaAtualizacao")]
        public DateTime LastUpdated { get; set; }

        public RosterBolsaFamiliaHistoryData[] History { get; set; } = [];

        public class RosterBolsaFamiliaHistoryData
        {
            [JsonProperty("DataEntrada")]
            public DateTime EntryDate { get; set; }
            [JsonProperty("DataSaida")]
            public DateTime DueDate { get; set; }
        }
    }
}