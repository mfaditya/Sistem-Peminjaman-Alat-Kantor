using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi.Context;
using WebAPi.Models;
using WebAPi.ViewModel;

namespace WebAPi.Repositories.Data
{
    public class StatusRepository : GeneralRepository<Status>
    {
        private MyContext myContext;
        public StatusRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        [HttpPut]
        public int Approve(RequestItem requestItem)
        {
            var request = new RequestItem
            {
                Id = requestItem.Id,
                UserId = requestItem.UserId,
                ItemId = requestItem.ItemId,
                StartDate = requestItem.StartDate,
                EndDate = requestItem.EndDate,
                Quantity = requestItem.Quantity,
                Notes = requestItem.Notes,
                StatusId = 4 //Already Approved
            };
            myContext.Entry(request).State = EntityState.Modified;
            myContext.SaveChanges();

            return 0;
        }

        [HttpPut]
        public int Reject(RequestItem requestItem)
        {
            var request = new RequestItem
            {
                Id = requestItem.Id,
                UserId = requestItem.UserId,
                ItemId = requestItem.ItemId,
                StartDate = requestItem.StartDate,
                EndDate = requestItem.EndDate,
                Quantity = requestItem.Quantity,
                Notes = requestItem.Notes,
                StatusId = 1 //Already Reject
            };
            myContext.Entry(request).State = EntityState.Modified;
            myContext.SaveChanges();

            return 0;
        }

        [HttpPut]
        public int TakeAnItem(RequestItem requestItem)
        {
            var request = new RequestItem
            {
                Id = requestItem.Id,
                UserId = requestItem.UserId,
                ItemId = requestItem.ItemId,
                StartDate = requestItem.StartDate,
                EndDate = requestItem.EndDate,
                Quantity = requestItem.Quantity,
                Notes = requestItem.Notes,
                StatusId = 5 //Already Take An Item
            };
            myContext.Entry(request).State = EntityState.Modified;
            myContext.SaveChanges();

            return 0;
        }

        [HttpPut]
        public int Return(RequestItem requestItem)
        {
            var request = new RequestItem
            {
                Id = requestItem.Id,
                UserId = requestItem.UserId,
                ItemId = requestItem.ItemId,
                StartDate = requestItem.StartDate,
                EndDate = requestItem.EndDate,
                Quantity = requestItem.Quantity,
                Notes = requestItem.Notes,
                StatusId = 2 //Already Return
            };
            myContext.Entry(request).State = EntityState.Modified;
            myContext.SaveChanges();

            return 0;
        }
    }
}
