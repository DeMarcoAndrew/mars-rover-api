using MarsRoverAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarsRoverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarsAPIController : ControllerBase
    {

        private IMarsAPIService _marsAPIService;

        public MarsAPIController(IMarsAPIService p_MarsAPIService)
        {
            _marsAPIService = p_MarsAPIService;
        }
 
        [HttpGet("curiosity")]
        public async Task<IActionResult> GetCuriosityRoverData(
            [FromQuery] int? sol = null, 
            [FromQuery] int? page = null, 
            [FromQuery] int? per_page = null
        )
        {
            try
            {
                return Ok(await _marsAPIService.GetCuriosityRoverDataAsync(MarsAPIConstants.CuriosityRoverPath, sol, page, per_page));
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
                return NotFound();
                //return Ok(await _marsAPIService.GetMarsAPIDataAsync(MarsAPIConstants.PerseveranceRoverPath, sol, page, per_page));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error! " + ex.Message);
            }
        }

        [HttpGet("insight")]
        public async Task<IActionResult> GetInSightLanderData(
            [FromQuery] int? sol = null, 
            [FromQuery] int? page = null, 
            [FromQuery] int? per_page = null
        )
        {
            try
            {
                return NotFound();
                //return Ok(await _marsAPIService.GetMarsAPIDataAsync(MarsAPIConstants.InSightLanderPath, sol, page, per_page));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error! " + ex.Message);
            }
        }
    }
}