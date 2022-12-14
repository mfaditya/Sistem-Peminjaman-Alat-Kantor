using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPi.Base;
using WebAPi.Context;
using WebAPi.Models;
using WebAPi.Repositories.Data;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : BaseController<ItemsRepository, Item>
    {
        private MyContext myContext;
        private ItemsRepository itemsRepository;
        public ItemController(ItemsRepository repository, MyContext myContext) : base(repository)
        {
            this.myContext = myContext;
            this.itemsRepository = repository;
        }

        //[HttpGet("Id")]
        //public ActionResult WhoRequestByItemId(int id)
        //{
        //    var dataItem = from U in myContext.Users
        //                   join A in myContext.Accounts on U.Id equals A.Id
        //                   join R in myContext.RequestItems on A.Id equals R.UserId
        //                   join I in myContext.Items on R.ItemId equals I.Id
        //                   where I.Id == id
        //                   select new
        //                   {
        //                       BorrowerName = U.FullName + " ",
        //                       QtyOfBorrowedItems = R.Quantity,
        //                       StartBorrowedDate = R.StartDate,
        //                       EndBorrowedDate = R.EndDate
        //                   };
        //    return Ok(dataItem);

        //}
    }
}
