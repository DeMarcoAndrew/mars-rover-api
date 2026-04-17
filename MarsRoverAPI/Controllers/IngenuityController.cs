using MarsRoverAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarsRoverAPI.Controllers
{
    [Route("api/ingenuity")]
    [ApiController]
    public class IngenuityController : ControllerBase
    {

        private IIngenuityHelicopterService _ingenuityHelicopterService;

        public IngenuityController(IIngenuityHelicopterService p_IngenuityHelicopterService)
        {
            _ingenuityHelicopterService = p_IngenuityHelicopterService;
        }

        [HttpGet("")]
        [HttpGet("{sol:int}")]
        [HttpGet("{earth_date}")]
        [HttpGet("latest")]
        public async Task<IActionResult> GetIngenuityHelicopterDataAsync(
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

                return Ok(await _ingenuityHelicopterService.GetIngenuityHelicopterDataAsync(sol, earth_date, latest, page, per_page, camera));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error! " + ex.Message);
            }
        }

        [HttpGet("images")]
        [HttpGet("{sol:int}/images")]
        [HttpGet("{earth_date}/images")]
        [HttpGet("images/latest")]
        public async Task<IActionResult> GetIngenuityHelicopterImages(
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

                var result = await _ingenuityHelicopterService.GetIngenuityHelicopterImagesAsync(sol, earth_date, latest, size, page, per_page, camera);

                return per_page == 1 && result.Count() > 0 ? Ok(result.Single()) : Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error! " + ex.Message);
            }
        }

    }
}