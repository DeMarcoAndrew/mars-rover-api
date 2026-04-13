using System.Text.Json.Serialization;

namespace MarsRoverAPI.Models.CuriosityRover
{
    public class LatestDataRoot
    {
        [JsonPropertyName("success")]
        public bool? Success { get; set; }

        [JsonPropertyName("latest_data")]
        public LatestData? LatestData { get; set; }
    }
}