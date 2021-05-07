using Microsoft.AspNetCore.Mvc;

namespace Shopping.Api.Controllers
{
    [ApiController]
    [Route("health")]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet()]
        public string IsAlive()
        {
            return "Alive";
        }
    }
}