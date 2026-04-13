using System.Text.Json.Serialization;
using MarsRoverAPI.ModelBase.Models;

namespace MarsRoverAPI.Models.CuriosityRover
{
    public class Root : RootBase<Image<ImageFiles, Camera>> { }
}
