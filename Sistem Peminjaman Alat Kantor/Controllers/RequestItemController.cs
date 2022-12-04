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
    public class RequestItemController : BaseController<RequestItemsRepository, RequestItem>
    {
        private RequestItemsRepository requestItemsRepository;
        private MyContext myContext;
        //public IConfiguration _configuration;
        public RequestItemController(RequestItemsRepository repository) : base(repository)
        {
            this.requestItemsRepository = repository;
            //this.myContext = myContext;
            //_configuration = config;
        }

        [HttpPost(("NewRequest"))]
        public ActionResult RequestItem(RequestItemVM requestItem)
        {
            try
            {
                var data = requestItemsRepository.RequestItem(requestItem);
                if (data > 0)
                {
                    //return StatusCode(400, new { status = HttpStatusCode.BadRequest, message = "Request Item Gagal" });
                    return Ok(new
                    {
                        StatusCode = 400,
                        Message = "Request Item Berhasil",
                        Data = data
                    });
                }
                else
                {
                    //var request = new RequestItem
                    //{
                    //    UserId = requestItem.UserId,
                    //    ItemId = requestItem.ItemId,
                    //    StartDate = requestItem.StartDate,
                    //    EndDate = requestItem.EndDate,
                    //    Quantity = requestItem.Quantity,
                    //    Notes = requestItem.Notes,
                    //    StatusId = 3 //Waiting for Approval"
                    //};
                    //myContext.RequestItems.Add(request);
                    //myContext.SaveChanges();

                    //var data = myContext.Items.Include(a => a.RequestItems).Where(e => e.Id == request.ItemId).FirstOrDefault();
                    //data.Quantity -= requestItem.Quantity;
                    //myContext.Entry(data).State = EntityState.Modified;
                    //myContext.SaveChanges();

                    //var user = myContext.Users.Where(u => u.Id == requestItem.UserId).FirstOrDefault();
                    //var dep = myContext.Departments.Where(d => d.Id == user.DepartmentId).FirstOrDefault();
                    //var currentItem = myContext.RequestItems.Where(i => i.UserId == user.Id).FirstOrDefault();
                    //var item = myContext.Items.Where(i => i.Id == requestItem.ItemId).FirstOrDefault();

                    //return StatusCode(200, new { status = HttpStatusCode.OK, message = "Request Item Berhasil" });
                    
                    return Ok(new
                    {
                        StatusCode = 400,
                        Message = "Request Item Gagal"
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
