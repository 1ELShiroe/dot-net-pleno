using Newtonsoft.Json;

namespace StallosDotnetPleno.Domain.Models.Roster
{
    public class RosterProtocolo
    {
        [JsonProperty("Protocolo")]
        public string? Protocol { get; set; }
    }
}