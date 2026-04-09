using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarsRoverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuriosityController : ControllerBase
    {

        // private ICuriosityRoverService _curiosityRoverService;

        // public CuriosityController(ICuriosityRoverService p_curiosityRoverService)
        // {
        //     _curiosityRoverService = p_curiosityRoverService;
        // }
        // {
        //     _planetPaintballBL = p_planetPaintballBL;
        // }
 
        // [HttpGet("VerifyCustomerCredentials")]
        // public IActionResult GetCustomerCredentials([FromQuery] string customerEmail, string customerPassword)
        // {
        //     try
        //     {
        //         //grab the curiosity rover data from the service
        //         return Ok();
        //     }
        //     catch (SqlException)
        //     {
        //         Log.Warning("User with these credentials do not match!");
        //         return NotFound();
        //     }
        // }

    }
}