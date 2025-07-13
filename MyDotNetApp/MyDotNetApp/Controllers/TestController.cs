using Microsoft.AspNetCore.Mvc;

namespace MyDotNetApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "aa Hello from Test API abc! testted" });
        }
    }
} 