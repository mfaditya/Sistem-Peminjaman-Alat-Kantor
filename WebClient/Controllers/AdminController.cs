using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Menu/Admin/Item")]
        public IActionResult Item()
        {
            var token = HttpContext.Session.GetString("token");
            ViewData["token"] = token;

            var jwtReader = new JwtSecurityTokenHandler();
            var jwt = jwtReader.ReadJwtToken(token);
            var id = jwt.Claims.First(c => c.Type == "Id").Value;
            var fullName = jwt.Claims.First(c => c.Type == "FullName").Value;
            ViewData["id"] = id;
            ViewData["fullName"] = fullName;
            return View();
        }

        public IActionResult ReturnItem()
        {
            var token = HttpContext.Session.GetString("token");
            ViewData["token"] = token;

            var jwtReader = new JwtSecurityTokenHandler();
            var jwt = jwtReader.ReadJwtToken(token);
            var id = jwt.Claims.First(c => c.Type == "Id").Value;
            var fullName = jwt.Claims.First(c => c.Type == "FullName").Value;
            ViewData["id"] = id;
            ViewData["fullName"] = fullName;
            return View();
        }

        public IActionResult TakeAnItem()
        {
            return View();
        }

    }
}
