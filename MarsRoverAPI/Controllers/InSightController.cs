using MarsRoverAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarsRoverAPI.Controllers
{
    [Route("api/insight")]
    [ApiController]
    public class InSightController : ControllerBase
    {

        private IInSightLanderService _inSightLanderService;

        public InSightController(IInSightLanderService p_InSightLanderService)
        {
            _inSightLanderService = p_InSightLanderService;
        }

        [HttpGet("")]
        [HttpGet("{sol:int}")]
        [HttpGet("{earth_date}")]
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
                return Ok(await _inSightLanderService.GetInSightLanderImagesAsync(sol, earth_date, page, per_page, camera));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error! " + ex.Message);
            }
        }


        [HttpGet("images")]
        [HttpGet("{sol:int}/images")]
        [HttpGet("{earth_date}/images")]
        public async Task<IActionResult> GetInSightLanderImages(
            [FromRoute] int? sol = null,
            [FromRoute] string? earth_date = null,
            [FromQuery] int? page = null,
            [FromQuery] int? per_page = null,
            [FromQuery] string? camera = null
        )
        {
            try
            {
                var result = await _inSightLanderService.GetInSightLanderImagesAsync(sol, earth_date, page, per_page, camera);

                return per_page == 1 && result.Count() > 0 ? Ok(result.OrderBy(x => Random.Shared.Next()).First()) : Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error! " + ex.Message);
            }
        }
    
    }
}