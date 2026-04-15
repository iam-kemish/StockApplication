using Microsoft.AspNetCore.Mvc;

namespace StockApplicationApi.Controllers
{
    [Route("api/Comment")]
    [ApiController]
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
