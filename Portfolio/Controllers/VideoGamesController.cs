using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class VideoGamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
