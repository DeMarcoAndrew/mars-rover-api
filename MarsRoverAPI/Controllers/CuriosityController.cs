using MarsRoverAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarsRoverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuriosityController : ControllerBase
    {

        private ICuriosityRoverService _curiosityRoverService;

        public CuriosityController(ICuriosityRoverService p_curiosityRoverService)
        {
            _curiosityRoverService = p_curiosityRoverService;
        }
 
        [HttpGet("Curiosity")]
        public async Task<IActionResult> GetCuriosityRoverData(
            [FromQuery] int? sol = null, 
            [FromQuery] int? page = null, 
            [FromQuery] int? per_page = null
        )
        {
            try
            {
                var result = await _curiosityRoverService.GetCuriosityRoverDataAsync(sol, page, per_page);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error! " + ex.Message);
            }
        }
    }
}