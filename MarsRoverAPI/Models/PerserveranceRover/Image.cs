using System.Text.Json.Serialization;
using MarsRoverAPI.ModelBase.Models;

namespace MarsRoverAPI.PerserveranceRover.Models
{
    public class Image : ImageBase
    {
        [JsonPropertyName("extended")]
        public Extended? Extended { get; set; }
    }
}
