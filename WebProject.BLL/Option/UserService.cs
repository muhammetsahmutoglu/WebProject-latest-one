using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.BLL.BaseService;
using WebProject.Data.ORM.Entity;
using WebProject.Data.ORM.Enum;

namespace WebProject.BLL.Option
{
   public class UserService:ServiceBase<User>
    {
        public bool CheckCredentials(string userName, string password)
        {
            return Any(x => x.UserName == userName && x.Password == password);
        }

        public User FindByUserName(string userName)
        {
            return GetByDefault(x => x.UserName == userName);
        }

        public User FindByUserNameOrEmail(string user)
        {
            return GetFirstOrDefault(x => (x.UserName == user || x.Email == user) && x.Status != Status.Deleted);
        }

        public bool CheckCredentialsFromWebSerice(string user, string password)
        {
            return Any(x => (x.UserName == user || x.Email == user) && (x.Password == password && x.Status != Status.Deleted));
        }
    }
}
