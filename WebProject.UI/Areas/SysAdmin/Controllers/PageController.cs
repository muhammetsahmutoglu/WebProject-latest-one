using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.BLL.Option;
using WebProject.Data.ORM.Entity;
using WebProject.UI.Areas.SysAdmin.Models.DTO;
using WebProject.UI.Areas.SysAdmin.Models.VM;

namespace WebProject.UI.Areas.SysAdmin.Controllers
{
    public class PageController : Controller
    {
        UserService userService;
        PageService pageService;
        public PageController()
        {
            userService = new UserService();
            pageService = new PageService();
        }
        public ActionResult Add()
        {
            Page page = new Page();
            return View(page);
        }
        [HttpPost]
        public ActionResult Add(Page page,HttpPostedFileBase image)
        {
            User user = userService.GetByDefault(x => x.UserName == User.Identity.Name);
            page.UserID = user.ID;
            if (pageService.Any(x=>x.Name==page.Name))
            {
                return View();
            }
            else
            {
                if (image == null)
                {
                    pageService.Add(page);
                }
                else
                {
                    page.ImageUrl = new byte[image.ContentLength];
                    image.InputStream.Read(page.ImageUrl, 0, image.ContentLength);
                    pageService.Add(page);
                }
            }

            return Redirect("/SysAdmin/Page/List");
        }

        public ActionResult List()
        {
            List<Page> pages = pageService.GetActive().Take(10).OrderBy(x => x.Name).ToList();
            return View(pages);
        }

        public ActionResult Show(int id)
        {
            PageVM model = new PageVM()
            {
                UserName = pageService.GetByID(id).User.UserName,
                page = pageService.GetByID(id),
                pages = pageService.GetActive().Take(10).OrderByDescending(x => x.AddDate).ToList()
            };
            return View(model);
        }

        public ActionResult Update(int id)
        {
            Page page = pageService.GetByID(id);
            PageDTO pageDTO = new PageDTO()
            {
                ID = page.ID,
                Name = page.Name,
                Explanation = page.Explanation,
                ImageUrl = page.ImageUrl
            };
            return View(pageDTO);
        }

        [HttpPost]
        public ActionResult Update(PageDTO pageDTO,HttpPostedFileBase image)
        {
            Page page = pageService.GetByID(pageDTO.ID);
            page.Name = pageDTO.Name;
            page.Explanation = pageDTO.Explanation;
            if (image == null)
            {
                pageService.Update(page);
            }
            else
            {
                page.ImageUrl = new byte[image.ContentLength];
                image.InputStream.Read(page.ImageUrl, 0, image.ContentLength);
                pageService.Update(page);
            }
            
            return Redirect("/SysAdmin/Page/Show"+"/"+page.ID);
        }

        public ActionResult Delete(int id)
        {
            Page page = pageService.GetByID(id);
            pageService.Remove(page);
            return Redirect("/SysAdmin/Page/List");
        }
    }
}