using Microsoft.AspNetCore.Mvc;

namespace Project.Api.Shared.Exceptions
{
    public class UnauthorizedException : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
