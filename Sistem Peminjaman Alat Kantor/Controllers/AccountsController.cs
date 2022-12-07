using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPi.Base;
using WebAPi.Context;
using WebAPi.Models;
using WebAPi.Repositories.Data;
using WebAPi.ViewModel;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<AccountRepository, Account>
    {
        private AccountRepository  accountRepository;
        private MyContext myContext;
        public IConfiguration _configuration;
        public AccountsController(IConfiguration config, AccountRepository accountRepository, MyContext myContext) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this.myContext = myContext;
            _configuration = config;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginVM login)
        {
            try
            {
                var data = accountRepository.Login(login);

                if (data != null)
                {
                    var roles = myContext.AccountRoles.Where(ra => ra.AccountId == data.Id).ToList();
                    var claims = new List<Claim> {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", data.Id.ToString()),
                        new Claim("FullName", data.FullName),
                        new Claim("Email", data.Email),
                        //new Claim("Role", data.Roles)
                    }; 
                    foreach (var item in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, myContext.Roles.Where(r => r.Id == item.RoleId).FirstOrDefault().Name));
                    }

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));

                    //string tokenCode = new JwtSecurityTokenHandler().WriteToken(token);
                    //return Ok(new
                    //{
                    //    StatusCode = 200,
                    //    Message = "Login Success",
                    //    token = tokenCode
                    //});
                    //return Ok(new JwtSecurityTokenHandler().WriteToken(token));

                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 400,
                        Message = "Email atau Password Anda Salah!"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }

        [HttpPut]
        [Route("Change Password")]
        public ActionResult ChangePassword(ChangePasswordVM changePassword)
        {
            try
            {
                var data = accountRepository.ChangePassword(changePassword);
                if (data == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 400,
                        Message = "Kamu Gagal Daftar"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Kamu Berhasil Daftar",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }

        [HttpPost]
        [Route("Forgot Password")]
        public ActionResult ForgotPassword(ForgotPasswordVM forgotPassword)
        {
            try
            {
                var data = accountRepository.ForgotPassword(forgotPassword);
                if (data != null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Kamu Berhasil Daftar"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 400,
                        Message = "Kamu Gagal Daftar",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }
    }
}
