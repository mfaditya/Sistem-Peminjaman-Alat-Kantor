using WebAPi.Context;
using WebAPi.Models;

namespace WebAPi.Repositories.Data
{
    public class ItemsRepository : GeneralRepository<Item>
    {
        private MyContext myContext;
        public ItemsRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
