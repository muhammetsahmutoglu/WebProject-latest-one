using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebProject.BLL.Option;
using WebProject.Data.ORM.Entity;
using WebProject.UI.Models.VM;

namespace WebProject.UI.Controllers
{
    public class AccountController : Controller
    {
        UserService userService;
        public AccountController()
        {
            userService = new UserService();
        }
        
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                User user = userService.GetByDefault(x => x.UserName == User.Identity.Name);
                if (user.IsAdmin)
                {
                    return Redirect("/SysAdmin/Sys/Dashboard");
                }
                else
                {
                    return Redirect("/Home/Index");
                }
                
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM credentials)
        {
            if (userService.CheckCredentials(credentials.UserName, credentials.Password))
            {
                User user = userService.FindByUserName(credentials.UserName);
                if (user.IsAdmin)
                {
                    if (user.Status==Data.ORM.Enum.Status.Deleted)
                    {
                        return View();
                    }
                    else
                    {
                        Session["name"] = user.UserName;
                        Session["ID"] = user.ID;
                        string cookie = user.UserName;
                        FormsAuthentication.SetAuthCookie(cookie, true);
                        return Redirect("/SysAdmin/Sys/Dashboard");

                    }
                   
                }
                else
                {
                    if (user.Status==Data.ORM.Enum.Status.Deleted)
                    {
                        return View();
                    }
                    else
                    {
                        return Redirect("/Home/Index");
                    }                   
                    
                }
               
            }
            else
            {
                return View();  
            }
            
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Account/Login");
        }
    }
}