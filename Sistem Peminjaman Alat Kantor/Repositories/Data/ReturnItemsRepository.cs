using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi.Context;
using WebAPi.Models;
using WebAPi.ViewModel;

namespace WebAPi.Repositories.Data
{
    public class ReturnItemsRepository : GeneralRepository<ReturnItem>
    {
        private MyContext myContext;
        public ReturnItemsRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        [HttpPost]
        public int ReturnItem(ReturnItem returnItem)
        {
            var rtrnItem = new ReturnItem
            {
                RequestItemId = returnItem.RequestItemId,
                Notes = returnItem.Notes
            };

            myContext.ReturnItems.Add(rtrnItem);
            myContext.SaveChanges();

            var dataRequest = myContext.RequestItems.Where(R => R.Id == returnItem.RequestItemId).FirstOrDefault();
            var data = myContext.Items.Include(I => I.RequestItems).Where(I => I.Id == dataRequest.ItemId).FirstOrDefault();
            data.Quantity += dataRequest.Quantity;
            myContext.Entry(data).State = EntityState.Modified;
            //myContext.SaveChanges();

            dataRequest.StatusId = 2; // Returned
            myContext.Entry(dataRequest).State = EntityState.Modified;

            myContext.SaveChanges();
            return 0;
        }
    }
}
