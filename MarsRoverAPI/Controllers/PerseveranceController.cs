using MarsRoverAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarsRoverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerseveranceController : ControllerBase
    {

        private IPerseveranceRoverService _perseveranceRoverService;

        public PerseveranceController(IPerseveranceRoverService p_PerseveranceRoverService)
        {
            _perseveranceRoverService = p_PerseveranceRoverService;
        }

        [HttpGet("perseverance")]
        [HttpGet("perseverance/{sol:int}")]
        [HttpGet("perseverance/{earth_date}")]
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
        [HttpGet("perseverance/{sol:int}/images")]
        [HttpGet("perseverance/{earth_date}/images")]
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

                return per_page == 1 && result.Count() > 0 ? Ok(result.Single()) : Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error! " + ex.Message);
            }
        }
    }
}