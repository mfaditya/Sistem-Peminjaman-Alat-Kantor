using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Menu/RequestItem")]
        public IActionResult RequestItem()
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

        [HttpGet]
        public String Get()
        {
            var token = HttpContext.Session.GetString("token");
            ViewData["token"] = token;

            var jwtReader = new JwtSecurityTokenHandler();
            var jwt = jwtReader.ReadJwtToken(token);
            var id = jwt.Claims.First(c => c.Type == "Id").Value;

            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://localhost:7095/api/RequestItem/" + id).Result;
            var apiResponse = response.Content.ReadAsStringAsync();
            return apiResponse.Result;
        }
    }
}
