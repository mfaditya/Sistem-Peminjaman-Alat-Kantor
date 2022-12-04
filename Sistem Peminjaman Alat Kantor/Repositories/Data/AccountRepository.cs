using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi.Context;
using WebAPi.Handlers;
using WebAPi.Models;
using WebAPi.ViewModel;

namespace WebAPi.Repositories.Data
{
    public class AccountRepository : GeneralRepository<Account>
    {
        private MyContext myContext;
        public AccountRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        [HttpPost]
        public ResponseLoginVm Login(LoginVM login)
        {
            ResponseLoginVm responseLogin = new ResponseLoginVm();
            var data = myContext.Users.Where(u => u.Email == login.Email).SingleOrDefault();
            if (data == null)
            {
                return responseLogin;
            }
            else
            {
                var result = myContext.Accounts.Where(a => a.Id == data.Id).SingleOrDefault();
                if(result == null)
                {
                    return responseLogin;
                }
                else
                {
                    var validatePass = Hashing.ValidatePassword(login.Password, result.Password);
                    if (validatePass)
                    {
                        var roles = myContext.AccountRoles.Where(r => r.AccountId == result.Id).SingleOrDefault();

                        var rolename = myContext.Roles.Where(r => r.Id == roles.RoleId).SingleOrDefault();
                        responseLogin.Id = data.Id;
                        responseLogin.FullName = data.FullName;
                        responseLogin.Email = data.Email;
                        responseLogin.Roles = rolename.Name;

                        return responseLogin;
                    }
                }
            }
            return null;
        }
        [HttpPut]
        public int ChangePassword(ChangePasswordVM changePassword)
        {
            var data = myContext.Accounts
                .Include(x => x.User)
                .SingleOrDefault(x => x.User.Email.Equals(changePassword.Email));
            if (data != null)
            {

                if (Hashing.ValidatePassword(changePassword.OldPassword, data.Password))
                {
                    data.Password = Hashing.HashPassword(changePassword.NewPassword);
                    myContext.Entry(data).State = EntityState.Modified;
                    var result = myContext.SaveChanges();
                    if (result > 0)
                    {
                        return result;
                    }
                    return 0;
                }
                return 0;
            }

            return 0;
        }
        [HttpPost]
        public int ForgotPassword(ForgotPasswordVM forgotPassword)
        {
            var data = myContext.Accounts.
                Where(u => u.User.Email == forgotPassword.Email && u.User.FullName.Equals(forgotPassword.FullName)).SingleOrDefault();
            if (data != null)
            {
                data.Password = Hashing.HashPassword(forgotPassword.Password);
                myContext.Entry(data).State = EntityState.Modified;
                var resultUser = myContext.SaveChanges();
            }
            return 0;
        }
    }
}
