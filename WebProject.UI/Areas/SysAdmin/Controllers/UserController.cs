using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.BLL.Option;
using WebProject.Data.ORM.Entity;
using WebProject.UI.Areas.SysAdmin.Models.DTO;

namespace WebProject.UI.Areas.SysAdmin.Controllers
{
    public class UserController : Controller
    {
        public UserService userService;
        public UserController()
        {
            userService = new UserService();
        }
        public ActionResult Add()
        {
            UserDTO user = new UserDTO();
            return View(user);
        }
        [HttpPost]
        public ActionResult Add(UserDTO userDTO,HttpPostedFileBase image)
        {//
            User user = new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                UserName = userDTO.UserName,
                Email = userDTO.Email,
                Password = userDTO.Password
        };
            if (userService.FindByUserName(user.UserName)==null)
            {
                
                if (userDTO.IsAdmin == "Admin")
                {
                    user.IsAdmin = true;
                }
                else
                {
                    user.IsAdmin = false;
                }
                if (image==null)
                {
                    userService.Add(user);
                }
                else
                {
                    user.ProfilePhoto = new byte[image.ContentLength];
                    image.InputStream.Read(user.ProfilePhoto, 0, image.ContentLength);
                }
                
                userService.Add(user);
            }
           
            return Redirect("/SysAdmin/User/List");
        }

        public ActionResult List()
        {
            List<User> model = userService.GetActive().Take(10).OrderByDescending(x => x.FirstName).ToList();
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            
            userService.Remove(id);
            return Redirect("/SysAdmin/User/List");
        }

        public ActionResult Update(int id)
        {
            User user = userService.GetByID(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Update(UserDTO userDTO)
        {
            User user = userService.GetByID(userDTO.ID);            
            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.UserName = userDTO.UserName;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;
            if (userDTO.IsAdmin == "Admin")
            {
                user.IsAdmin = true;
            }
            else
            {
                user.IsAdmin = false;
            }
            userService.Update(user);
            return Redirect("/SysAdmin/User/List");
            
        }

        public ActionResult Show(int id)
        {
            User user = userService.GetByID(id);
            return View(user);
        }
    }
}