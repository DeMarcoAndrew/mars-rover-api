using MarsRoverAPI.Models.CuriosityRover;
using MarsRoverAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarsRoverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarsAPIController : ControllerBase
    {

        private ICuriosityRoverService _curiosityRoverService;
        private IPerseveranceRoverService _perseveranceRoverService;

        public MarsAPIController(ICuriosityRoverService p_CuriosityRoverService, IPerseveranceRoverService p_PerseveranceRoverService)
        {
            _curiosityRoverService = p_CuriosityRoverService;
            _perseveranceRoverService = p_PerseveranceRoverService;
        }
 
        [HttpGet("curiosity")]
        public async Task<IActionResult> GetCuriosityRoverData(
            [FromQuery] int? sol = null,
            [FromQuery] string? earth_date = null,
            [FromQuery] bool? latest = null,
            [FromQuery] int? page = null, 
            [FromQuery] int? per_page = null
        )
        {
            try
            {
                DateTime? earthDate = null;

                if (!string.IsNullOrWhiteSpace(earth_date))
                {
                    earthDate = DateTime.ParseExact(earth_date, "MM-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }

                return Ok(await _curiosityRoverService.GetCuriosityRoverDataAsync(MarsAPIConstants.CuriosityRoverPath, sol, earthDate, latest, page, per_page));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error! " + ex.Message);
            }
        }

        [HttpGet("curiosity/images")]
        public async Task<IActionResult> GetCuriosityRoverImages(
            [FromQuery] int? sol = null,
            [FromQuery] string? earth_date = null,
            [FromQuery] bool? latest = null,
            [FromQuery] string? size = null,
            [FromQuery] int? page = null, 
            [FromQuery] int? per_page = null
        )
        {
            try
            {
                DateTime? earthDate = null;

                if (!string.IsNullOrWhiteSpace(earth_date))
                {
                    earthDate = DateTime.ParseExact(earth_date, "MM-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }

                var result = await _curiosityRoverService.GetCuriosityRoverDataAsync(MarsAPIConstants.CuriosityRoverPath, sol, earthDate, latest, page, per_page);

                var imagesOnlyResult = size?.ToLower() switch
                {
                    "small" => result.Images.SelectMany(imgs => imgs.ImageFiles.Small).ToList(),
                    "medium" => result.Images.SelectMany(imgs => imgs.ImageFiles.Medium).ToList(),
                    "large" => result.Images.SelectMany(imgs => imgs.ImageFiles.Large).ToList(),
                    _ => result.Images.SelectMany(imgs => imgs.ImageFiles.Large).ToList()
                };

                return Ok(imagesOnlyResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error! " + ex.Message);
            }
        }

        [HttpGet("perseverance")]
        public async Task<IActionResult> GetPerseveranceRoverData(
            [FromQuery] int? sol = null, 
            [FromQuery] int? page = null, 
            [FromQuery] int? per_page = null
        )
        {
            try
            {
                return Ok(await _perseveranceRoverService.GetPerseveranceRoverDataAsync(MarsAPIConstants.PerseveranceRoverPath, sol, page, per_page));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error! " + ex.Message);
            }
        }

        // [HttpGet("insight")]
        // public async Task<IActionResult> GetInSightLanderData(
        //     [FromQuery] int? sol = null, 
        //     [FromQuery] int? page = null, 
        //     [FromQuery] int? per_page = null
        // )
        // {
        //     try
        //     {
        //         return Ok(await _marsAPIService.GetInSightLanderDataAsync(MarsAPIConstants.InSightLanderPath, sol, page, per_page));
        //     }
        //     catch (Exception ex)
        //     {
        //         return StatusCode(500, "Error! " + ex.Message);
        //     }
        // }
    }
}