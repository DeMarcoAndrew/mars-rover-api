using System.Text.Json.Serialization;
using MarsRoverAPI.ModelBase.Models;

namespace MarsRoverAPI.PerserveranceRover.Models
{
    public class Camera
    {
        [JsonPropertyName("camera_vector")]
        public string? CameraVector { get; set; }

        [JsonPropertyName("camera_position")]
        public string CameraPosition { get; set; }
    }
}
