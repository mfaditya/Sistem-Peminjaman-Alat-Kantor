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
            //var returnItm = new ReturnItem
            //{
            //    RequestItemId = returnItem.RequestItemId,
            //    Notes = returnItem.Notes
            //};
            //myContext.ReturnItems.Add(returnItm);
            //myContext.SaveChanges();

            //var dataRequest = myContext.RequestItems.Where(R => R.Id == returnItem.RequestItemId).FirstOrDefault();
            //var data = myContext.Items.Include(I => I.RequestItems).Where(I => I.Id == dataRequest.ItemId).FirstOrDefault();
            //data.Quantity += dataRequest.Quantity;
            //myContext.Entry(data).State = EntityState.Modified;
            //myContext.SaveChanges();

            //dataRequest.StatusId = 2; // Returned
            //myContext.Entry(dataRequest).State = EntityState.Modified;
            //myContext.SaveChanges();

            //return StatusCode(200, new { status = HttpStatusCode.OK, message = "Return Item Berhasil" });
            try
            {
                var rtrnItem = new ReturnItem
                {
                    RequestItemId = returnItem.RequestItemId,
                    Notes = returnItem.Notes
                };

                myContext.ReturnItems.Add(rtrnItem);
                var result = myContext.SaveChanges();
                if (result > 0)
                {


                    var dataRequest = myContext.RequestItems.Where(R => R.Id == returnItem.RequestItemId).FirstOrDefault();
                    var data = myContext.Items.Include(I => I.RequestItems).Where(I => I.Id == dataRequest.ItemId).FirstOrDefault();
                    data.Quantity += dataRequest.Quantity;
                    myContext.Entry(data).State = EntityState.Modified;
                    //myContext.SaveChanges();

                    dataRequest.StatusId = 2; // Returned
                    myContext.Entry(dataRequest).State = EntityState.Modified;

                    myContext.SaveChanges();
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
