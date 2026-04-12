using System.Text.Json.Serialization;
using MarsRoverAPI.ModelBase.Models;

namespace MarsRoverAPI.PerseveranceRover.Models
{
    public class Camera : CameraBase
    {
        [JsonPropertyName("camera_vector")]
        public string? CameraVector { get; set; }

        [JsonPropertyName("camera_position")]
        public string CameraPosition { get; set; }
    }
}
