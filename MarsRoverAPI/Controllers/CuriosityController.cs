using MarsRoverAPI.Models.CuriosityRover;
using MarsRoverAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarsRoverAPI.Controllers
{
    [Route("api/curiosity")]
    [ApiController]
    public class CuriosityController : ControllerBase
    {

        private ICuriosityRoverService _curiosityRoverService;

        public CuriosityController(ICuriosityRoverService p_CuriosityRoverService)
        {
            _curiosityRoverService = p_CuriosityRoverService;
        }
 
        [HttpGet("")]
        [HttpGet("{sol:int}")]
        [HttpGet("{earth_date}")]
        [HttpGet("/latest")]
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

        [HttpGet("/images")]
        [HttpGet("{sol:int}/images")]
        [HttpGet("{earth_date}/images")]
        [HttpGet("images/latest")]
        public async Task<IActionResult> GetCuriosityRoverImages(
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

                var result = await _curiosityRoverService.GetCuriosityRoverImagesAsync(sol, earth_date, latest, page, per_page, camera);

                return per_page == 1 && result.Count() > 0 ? Ok(result.OrderBy(x => Random.Shared.Next()).First()) : Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error! " + ex.Message);
            }
        }
    }
}