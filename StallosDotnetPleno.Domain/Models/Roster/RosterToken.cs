using Newtonsoft.Json;

namespace StallosDotnetPleno.Domain.Models.Roster
{
    public class RosterToken
    {
        [JsonProperty("access_token")]
        public string? AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string? TokenType { get; set; }

        [JsonProperty("expires_in")]
        public double ExpiresIn { get; set; }
    }
}