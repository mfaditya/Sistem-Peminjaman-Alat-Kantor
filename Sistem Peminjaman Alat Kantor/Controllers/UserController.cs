using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPi.Base;
using WebAPi.Context;
using WebAPi.Models;
using WebAPi.Repositories.Data;
using WebAPi.ViewModel;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<UserRepository, User>
    {
        private UserRepository userRepository;
        private MyContext myContext;
        public UserController(UserRepository userRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
        }

        //[AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public ActionResult Register(RegisterVM register)
        {
            try
            {
                var data = userRepository.Register(register);
                if (data > 0)
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
