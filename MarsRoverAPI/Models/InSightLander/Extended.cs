using System.Text.Json.Serialization;

namespace MarsRoverAPI.Models.InSightLander
{
    public class Extended
    {
        [JsonPropertyName("localtime")]
        public string? Localtime { get; set; }
    }
}
