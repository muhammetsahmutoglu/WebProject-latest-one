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
    public class VideoCategoryController : Controller
    {
        UserService _UserService;
        VideoCategoryService _VideoCategoryService;
        public VideoCategoryController()
        {
            _UserService = new UserService();
            _VideoCategoryService = new VideoCategoryService();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(VideoCategory _VideoCategory)
        {
            _VideoCategory.UserID = _UserService.GetByDefault(x => x.UserName == User.Identity.Name).ID;
            _VideoCategoryService.Add(_VideoCategory);
            return Redirect("/SysAdmin/VideoCategory/List");
        }

        public ActionResult List()
        {
            List<VideoCategory> VideoCategorys = _VideoCategoryService.GetActive().Take(12).OrderByDescending(x => x.AddDate).ToList();
            return View(VideoCategorys);
        }

        public ActionResult Delete(int id)
        {
            VideoCategory VideoCategory = _VideoCategoryService.GetByID(id);
            _VideoCategoryService.Remove(VideoCategory);
            return Redirect("/SysAdmin/VideoCategory/List");
        }

        public ActionResult Update(int id)
        {
            VideoCategory VideoCategory = _VideoCategoryService.GetByID(id);
            VideoCategoryDTO VideoCategoryDTO = new VideoCategoryDTO()
            {
                ID = VideoCategory.ID,
                Explanation = VideoCategory.Explanation,
                Name = VideoCategory.Name,
            };
            return View(VideoCategoryDTO);
        }
        [HttpPost]
        public ActionResult Update(VideoCategoryDTO VideoCategoryDTO)
        {

            VideoCategory VideoCategory = _VideoCategoryService.GetByID(VideoCategoryDTO.ID);
            VideoCategory.Name = VideoCategoryDTO.Name;
            VideoCategory.Explanation = VideoCategoryDTO.Explanation;
            _VideoCategoryService.Update(VideoCategory);
            return Redirect("/SysAdmin/VideoCategory/List");

        }
    }
}