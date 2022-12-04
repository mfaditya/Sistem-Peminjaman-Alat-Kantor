using WebAPi.Context;
using WebAPi.Models;

namespace WebAPi.Repositories.Data
{
    public class RolesRepository : GeneralRepository<Role>
    {
        private MyContext myContext;
        public RolesRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
