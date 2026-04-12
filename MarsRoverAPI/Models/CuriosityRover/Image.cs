using System.Text.Json.Serialization;
using MarsRoverAPI.ModelBase.Models;

namespace MarsRoverAPI.CuriosityRover.Models
{
    public class Image<T, T1> : ImageBase<T, T1>
    { 
        [JsonPropertyName("site")]
        public string? Site { get; set; }
    }
}
