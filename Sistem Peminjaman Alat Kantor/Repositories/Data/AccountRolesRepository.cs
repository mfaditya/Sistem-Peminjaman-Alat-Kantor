using WebAPi.Context;
using WebAPi.Models;

namespace WebAPi.Repositories.Data
{
    public class AccountRolesRepository : GeneralRepository<AccountRole>
    {
        private MyContext myContext;
        public AccountRolesRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
