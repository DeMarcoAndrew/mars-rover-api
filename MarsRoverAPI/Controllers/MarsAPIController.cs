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
        [HttpGet("curiosity/{earth_date}")]
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
        [HttpGet("curiosity/{sol:int}/images")]
        [HttpGet("curiosity/{earth_date}/images")]
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

                return per_page == 1 && result.Count() > 0 ? Ok(result.Single()) : Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error! " + ex.Message);
            }
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

        [HttpGet("insight")]
        [HttpGet("insight/{sol:int}")]
        [HttpGet("insight/{earth_date}")]
        [HttpGet("insight/latest")]
        public async Task<IActionResult> GetInSightLanderData(
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


        [HttpGet("insight/images")]
        [HttpGet("insight/{sol:int}/images")]
        [HttpGet("insight/{earth_date}/images")]
        [HttpGet("insight/images/latest")]
        public async Task<IActionResult> GetInSightLanderPhotos(
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
        
        [HttpGet("ingenuity")]
        [HttpGet("ingenuity/{sol:int}")]
        [HttpGet("ingenuity/{earth_date}")]
        [HttpGet("ingenuity/latest")]
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

                return Ok(await _perseveranceRoverService.GetPerseveranceRoverDataAsync(sol, earth_date, latest, page, per_page, camera));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error! " + ex.Message);
            }
        }

        [HttpGet("ingenuity/images")]
        [HttpGet("ingenuity/{sol:int}/images")]
        [HttpGet("ingenuity/{earth_date}/images")]
        [HttpGet("ingenuity/images/latest")]
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