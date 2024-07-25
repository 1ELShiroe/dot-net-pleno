using Newtonsoft.Json;

namespace StallosDotnetPleno.Infrastructure.Services.Entities.Roster
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