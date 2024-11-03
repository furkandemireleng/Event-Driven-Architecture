using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [ApiController]
    [Route("api/c/[controller]")]
    public class PlatformsController: ControllerBase
    {
        public PlatformsController()
        {
            
        }

        [HttpGet]
        public ActionResult Test(){
            Console.WriteLine("there is still pain left");
            return Ok("Quick life");
        }

    }
}