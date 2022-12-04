using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi.Context;
using WebAPi.Models;
using WebAPi.Repositories.Interface;

namespace WebAPi.Repositories.Data
{
    public class DepartmentRepository : GeneralRepository<Department>
    {
        private MyContext myContext;
        public DepartmentRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
