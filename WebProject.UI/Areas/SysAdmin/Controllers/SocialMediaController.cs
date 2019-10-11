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
    public class SocialMediaController : Controller
    {
        UserService userService;
        SocialMediaAccountService socialMediaAccountService;
        public SocialMediaController()
        {
            userService = new UserService();
            socialMediaAccountService = new SocialMediaAccountService();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(SocialMediaAccount mediaAccount)
        {
            mediaAccount.UserID = userService.GetByDefault(X => X.UserName == User.Identity.Name).ID;
            socialMediaAccountService.Add(mediaAccount);
            return Redirect("/SysAdmin/SocialMedia/List");
        }

        public ActionResult List()
        {
            List<SocialMediaAccount> mediaAccounts = socialMediaAccountService.GetActive().Take(10).OrderByDescending(x => x.AddDate).ToList();
            return View(mediaAccounts);
        }

        public ActionResult Update(int id)
        {
            SocialMediaAccount mediaAccount = socialMediaAccountService.GetByID(id);
            SocialMediaDTO mediaDTO = new SocialMediaDTO()
            {
                ID=mediaAccount.ID,
                Name=mediaAccount.Name,
                Url=mediaAccount.Url,
            };

            return View(mediaDTO);
        }
        [HttpPost]
        public ActionResult Update(SocialMediaDTO mediaDTO)
        {
            SocialMediaAccount mediaAccount = socialMediaAccountService.GetByID(mediaDTO.ID);
            mediaAccount.Name = mediaDTO.Name;
            mediaAccount.Url = mediaDTO.Url;
            socialMediaAccountService.Update(mediaAccount);
            return  Redirect("/SysAdmin/SocialMedia/List");
        }

        public ActionResult Delete(int id)
        {
            SocialMediaAccount mediaAccount = socialMediaAccountService.GetByID(id);
            socialMediaAccountService.Remove(mediaAccount);
            return Redirect("/SysAdmin/SocialMedia/List");
        }
    }
}
