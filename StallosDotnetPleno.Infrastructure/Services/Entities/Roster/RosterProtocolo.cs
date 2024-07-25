using Newtonsoft.Json;

namespace StallosDotnetPleno.Infrastructure.Services.Entities.Roster
{
    public class RosterProtocolo
    {
        [JsonProperty("Protocolo")]
        public string? Protocol { get; set; }
    }
}