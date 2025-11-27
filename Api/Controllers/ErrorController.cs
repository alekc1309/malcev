using Microsoft.AspNetCore.Mvc;

namespace Project.Api.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)] //  скрыть от Swagger
    [ApiController]
    [Route("api/[controller]")]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Error()
        {
            return Problem();
        }
    }
}