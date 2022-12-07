using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Menu/RequestItem/NeedsApproval")]
        public IActionResult NeedsApproval()
        {
            return View();
        }
    }
}
