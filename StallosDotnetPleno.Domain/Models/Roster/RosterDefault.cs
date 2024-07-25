using Newtonsoft.Json;

namespace StallosDotnetPleno.Domain.Models.Roster
{
    public class RosterDefault<T>
    {
        [JsonProperty("Encontrado")]
        public bool IsFound { get; set; }

        [JsonProperty("Objeto")]
        public T? Data { get; set; }
    }
}