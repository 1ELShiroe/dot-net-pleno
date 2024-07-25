using Newtonsoft.Json;

namespace StallosDotnetPleno.Infrastructure.Services.Entities.Roster
{
    public class RosterPep
    {
        [JsonProperty(nameof(Id))]
        public string? Id { get; set; }
        [JsonProperty(nameof(CPF))]
        public string? CPF { get; set; }
        [JsonProperty("Nome")]
        public string? Name { get; set; }
        [JsonProperty("Referencia")]
        public string? Reference { get; set; }
        [JsonProperty("NivelFuncao")]
        public string? FuncLevel { get; set; }
        [JsonProperty("DescricaoFuncao")]
        public string? FuncDescription { get; set; }
        [JsonProperty("SiglaFuncao")]
        public string? FuncAcronym { get; set; }
        [JsonProperty("DataFimCarencia")]
        public string? GraceDateEnd { get; set; }
        [JsonProperty("DataFimExercicio")]
        public string? ExerciseDateEnd { get; set; }
        [JsonProperty("DataInicioExercicio")]
        public string? ExerciseDateStart { get; set; }
    }
}