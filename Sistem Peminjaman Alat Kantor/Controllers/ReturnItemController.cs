using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi.Base;
using WebAPi.Context;
using WebAPi.Models;
using WebAPi.Repositories.Data;
using WebAPi.ViewModel;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnItemController : BaseController<ReturnItemsRepository, ReturnItem>
    {
        private ReturnItemsRepository returnItemsRepository;
        private MyContext myContext;
        public ReturnItemController(ReturnItemsRepository repository, MyContext myContext) : base(repository)
        {
            this.returnItemsRepository = repository;
            this.myContext = myContext;
        }

        [HttpPost("NewReturn")]
        public ActionResult ReturnItem(ReturnItem returnItem)
        {
            try
            {
                var data = returnItemsRepository.ReturnItem(returnItem);
                if (data > 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Has Returned",
                        Data = data
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 400,
                        Message = "Data Hasn't Retruned"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }
    }
}
