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
            [FromQuery] DateTime? earth_date = null,
            [FromQuery] bool? latest = null,
            [FromQuery] int? page = null, 
            [FromQuery] int? per_page = null
        )
        {
            try
            {
                return Ok(await _curiosityRoverService.GetCuriosityRoverDataAsync(MarsAPIConstants.CuriosityRoverPath, sol, earth_date, latest, page, per_page));
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