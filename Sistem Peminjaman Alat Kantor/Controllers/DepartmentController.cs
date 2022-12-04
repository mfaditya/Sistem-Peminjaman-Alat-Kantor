using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPi.Base;
using WebAPi.Context;
using WebAPi.Models;
using WebAPi.Repositories.Data;
using WebAPi.Repositories.Interface;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController<DepartmentRepository, Department>
    {
        private DepartmentRepository departmentRepository;
        private MyContext myContext;
        //public IConfiguration configuration;
        public DepartmentController(DepartmentRepository departmentRepository, MyContext myContext) : base(departmentRepository)
        {
            this.myContext = myContext;
            this.departmentRepository = departmentRepository;
            //configuration = config;
        }

        [HttpGet("Admin")]
        public ActionResult GetDeptAdmin()
        {
            var admin = from U in myContext.Users
                        join D in myContext.Departments on U.DepartmentId equals D.Id
                        where U.DepartmentId == 1
                        select new
                        {
                            User = U.FullName,
                            Department = D.Name
                        };
            return Ok(admin);
        }

        [HttpGet("HR")]
        public ActionResult GetDeptHR()
        {
            var hr = from U in myContext.Users
                     join D in myContext.Departments on U.DepartmentId equals D.Id
                     where U.DepartmentId == 2
                     select new
                     {
                         User = U.FullName,
                         Department = D.Name
                     };
            return Ok(hr);
        }

        [HttpGet("ApplicationDevelopment")]
        public ActionResult GetDeptAppDev()
        {
            var appdev = from U in myContext.Users
                     join D in myContext.Departments on U.DepartmentId equals D.Id
                     where U.DepartmentId == 3
                     select new
                     {
                         User = U.FullName,
                         Department = D.Name
                     };
            return Ok(appdev);
        }

        [HttpGet("ManagementBusinessService ")]
        public ActionResult GetDeptMBS()
        {
            var mbs = from U in myContext.Users
                         join D in myContext.Departments on U.DepartmentId equals D.Id
                         where U.DepartmentId == 4
                         select new
                         {
                             User = U.FullName,
                             Department = D.Name
                         };
            return Ok(mbs);
        }
        //[HttpGet("DeptAdmin")]
        //public ActionResult GetDeptAdmin()
        //{
        //    try
        //    {
        //        var data = departmentRepository.GetDeptAdmin();
        //        //return Ok(new
        //        //{
        //        //    StatusCode = 200,
        //        //    Message = "Data Berhasil",
        //        //    Data = data
        //        //});
        //        if (data == 0)
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 200,
        //                Message = "Kamu Berhasil Daftar",
        //                Data = data
        //            });
        //        }
        //        else
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 400,
        //                Message = "Kamu Gagal Daftar",
        //                Data = data
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new
        //        {
        //            StatusCode = 400,
        //            Message = ex.Message,
        //        });
        //    }
        //}
    }
}
