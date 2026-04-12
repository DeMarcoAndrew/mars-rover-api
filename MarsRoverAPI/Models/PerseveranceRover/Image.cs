using System.Text.Json.Serialization;
using MarsRoverAPI.ModelBase.Models;

namespace MarsRoverAPI.PerseveranceRover.Models
{
    public class Image<T, T1> : ImageBase<T, T1>
    {
        [JsonPropertyName("extended")]
        public Extended? Extended { get; set; }

        [JsonPropertyName("site")]
        public int? Site { get; set; }
    }
}
