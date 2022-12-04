using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi.Context;
using WebAPi.Handlers;
using WebAPi.Models;
using WebAPi.Repositories.Interface;
using WebAPi.ViewModel;
using static WebAPi.Handlers.Hashing;

namespace WebAPi.Repositories.Data
{
    public class UserRepository : GeneralRepository<User>
    {
        private MyContext myContext;
        public UserRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        [HttpPost]
        public int Register(RegisterVM register)
        {
            var id = myContext.Users.SingleOrDefault(x => x.Id.Equals(register.Id));
            var data = myContext.Users.SingleOrDefault(x => x.Email.Equals(register.Email));
            int result = 0;
            if (id == null && data == null)
            {
                User user = new User()
                {
                    Id = register.Id,
                    FullName = register.FullName,
                    Gender = register.Gender,
                    BirthDate = register.BirthDate,
                    Address = register.Address,
                    Phone = register.Phone,
                    Email = register.Email,
                    DepartmentId = register.DepartmentId
                };
                myContext.Users.Add(user);
                //myContext.SaveChanges();

                var accounts = new Account()
                {
                    Id = register.Id,
                    Password = Hashing.HashPassword(register.Password)
                };
                myContext.Accounts.Add(accounts);
                //myContext.SaveChanges();

                var accountRoles = new AccountRole()
                {
                    AccountId = register.Id,
                    RoleId = register.RoleId
                };
                myContext.AccountRoles.Add(accountRoles);
                result = myContext.SaveChanges();
            }
            
            return result;
        }
    }
}
