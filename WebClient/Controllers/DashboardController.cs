﻿using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class DashboardController : Controller
    {
        [Route("Dashboard/Employee")]
        public IActionResult Employee()
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

        [Route("Dashboard/Manager")]
        public IActionResult Manager()
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

        [Route("Dashboard/Admin")]
        public IActionResult Admin()
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
    }
}
