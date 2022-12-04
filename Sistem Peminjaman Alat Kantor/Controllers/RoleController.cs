using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPi.Base;
using WebAPi.Models;
using WebAPi.Repositories.Data;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController<RolesRepository, Role>
    {
        public RoleController(RolesRepository repository) : base(repository)
        {
        }
    }
}
