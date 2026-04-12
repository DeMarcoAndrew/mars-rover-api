using System.Text.Json.Serialization;
using MarsRoverAPI.ModelBase.Models;

namespace MarsRoverAPI.PerserveranceRover.Models
{
    public class Extended
    {
        [JsonPropertyName("mastAz")]
        public string? MastAz { get; set; }

        [JsonPropertyName("mastEl")]
        public string? MastEl { get; set; }

        [JsonPropertyName("sclk")]
        public string? SCLK { get; set; }

        [JsonPropertyName("scaleFactor")]
        public string? ScaleFactor { get; set; }

        [JsonPropertyName("xyz")]
        public string? XYZ { get; set; }

        [JsonPropertyName("subFrameRect")]
        public string? SubframeRect { get; set; }

        [JsonPropertyName("dimension")]
        public string? Dimension { get; set; }
    }
}
