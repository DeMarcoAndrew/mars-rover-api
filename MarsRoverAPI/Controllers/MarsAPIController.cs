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
        [HttpGet("curiosity/{sol:int}")]
        [HttpGet("curiosity/{earth_date:string}")]
        [HttpGet("curiosity/latest")]
        public async Task<IActionResult> GetCuriosityRoverData(
            [FromRoute] int? sol = null,
            [FromRoute] string? earth_date = null,
            [FromQuery] int? page = null,
            [FromQuery] int? per_page = null,
            [FromQuery] string? camera = null
        )
        {
            try
            {
                bool latest = false;

                if (Request != null && Request.Path.HasValue && Request.Path.Value.Contains("/latest", StringComparison.OrdinalIgnoreCase))
                {
                    latest = true;
                }

                return Ok(await _curiosityRoverService.GetCuriosityRoverDataAsync(sol, earth_date, latest, page, per_page, camera));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error! " + ex.Message);
            }
        }

        [HttpGet("curiosity/images")]
        [HttpGet("curiosity/images/{sol:int}")]
        [HttpGet("curiosity/images/{earth_date:string}")]
        [HttpGet("curiosity/images/latest")]
        public async Task<IActionResult> GetCuriosityRoverImages(
            [FromRoute] int? sol = null,
            [FromRoute] string? earth_date = null,
            [FromQuery] string? size = null,
            [FromQuery] int? page = null,
            [FromQuery] int? per_page = null,
            [FromQuery] string? camera = null
        )
        {
            try
            {
                bool latest = false;

                if (Request != null && Request.Path.HasValue && Request.Path.Value.Contains("/latest", StringComparison.OrdinalIgnoreCase))
                {
                    latest = true;
                }

                var result = await _curiosityRoverService.GetCuriosityRoverImagesAsync(sol, earth_date, latest, size, page, per_page, camera);

                return per_page == 1 && result.Count() == 1 ? Ok(result.Single()) : Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error! " + ex.Message);
            }
        }

        [HttpGet("perseverance")]
        [HttpGet("perseverance/{sol:int}")]
        [HttpGet("perseverance/{earth_date:string}")]
        [HttpGet("perseverance/latest")]
        public async Task<IActionResult> GetPerseveranceRoverData(
            [FromRoute] int? sol = null,
            [FromRoute] string? earth_date = null,
            [FromQuery] int? page = null,
            [FromQuery] int? per_page = null,
            [FromQuery] string? camera = null
        )
        {
            try
            {
                bool latest = false;

                if (Request != null && Request.Path.HasValue && Request.Path.Value.Contains("/latest", StringComparison.OrdinalIgnoreCase))
                {
                    latest = true;
                }

                return Ok(await _perseveranceRoverService.GetPerseveranceRoverDataAsync(sol, earth_date, latest, page, per_page, camera));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error! " + ex.Message);
            }
        }

        [HttpGet("perseverance/images")]
        [HttpGet("perseverance/images/{sol:int}")]
        [HttpGet("perseverance/images/{earth_date:string}")]
        [HttpGet("perseverance/images/latest")]
        public async Task<IActionResult> GetPerseveranceRoverImages(
            [FromRoute] int? sol = null,
            [FromRoute] string? earth_date = null,
            [FromQuery] string? size = null,
            [FromQuery] int? page = null,
            [FromQuery] int? per_page = null,
            [FromQuery] string? camera = null
        )
        {
            try
            {
                bool latest = false;

                if (Request != null && Request.Path.HasValue && Request.Path.Value.Contains("/latest", StringComparison.OrdinalIgnoreCase))
                {
                    latest = true;
                }

                var result = await _perseveranceRoverService.GetPerseveranceRoverImagesAsync(sol, earth_date, latest, size, page, per_page, camera);

                return per_page == 1 && result.Count() == 1 ? Ok(result.Single()) : Ok(result);
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