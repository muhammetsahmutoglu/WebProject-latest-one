using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.BLL.Option;
using WebProject.Data.ORM.Entity;
using WebProject.UI.Areas.SysAdmin.Models.DTO;
using WebProject.UI.Areas.SysAdmin.Models.VM;

namespace WebProject.UI.Areas.SysAdmin.Controllers
{
    public class VideoController : Controller
    {
        UserService _UserService;
        VideoService _VideoService;
        VideoCategoryService _VideoCategoryService;
        public VideoController()
        {
            _UserService = new UserService();
            _VideoService = new VideoService();
            _VideoCategoryService = new VideoCategoryService();
        }
        public ActionResult Add()
        {
            VideoVM model = new VideoVM()
            {
                Categories = _VideoCategoryService.GetActive(),
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(VideoVM _VideoVM, HttpPostedFileBase videoFile)
        {
            string fileName = Path.GetFileName(videoFile.FileName);
            videoFile.SaveAs(Server.MapPath("~/Content/VideoFiles/" + fileName));
            _VideoVM.Video.UserID = _UserService.GetByDefault(x => x.UserName == User.Identity.Name).ID;
            _VideoVM.Video.Url = "~/Content/VideoFiles/" + fileName;
            _VideoVM.Video.Name = videoFile.FileName;
            _VideoVM.Video.VideoCategoryID = _VideoCategoryService.GetByDefault(x => x.Name == _VideoVM.CategoryName).ID;
            _VideoService.Add(_VideoVM.Video);
            return Redirect("/SysAdmin/Video/List");
        }

        public ActionResult List()
        {
            VideoVM model = new VideoVM()
            {
                Videos = _VideoService.GetActive(),
                Categories = _VideoCategoryService.GetActive()
            };
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            Video Video = _VideoService.GetByID(id);
            _VideoService.Remove(Video);
            return Redirect("/SysAdmin/Video/List");
        }

        public ActionResult Update(int id)
        {
            Video Video = _VideoService.GetByID(id);
            VideoDTO VideoDTO = new VideoDTO()
            {
                ID = Video.ID,
                Name = Video.Name,
                Url = Video.Url,

            };
            return View(VideoDTO);
        }
        [HttpPost]
        public ActionResult Update(VideoDTO VideoDTO)
        {

            Video Video = _VideoService.GetByID(VideoDTO.ID);
            Video.ID = VideoDTO.ID;
            Video.Name = VideoDTO.Name;
            Video.Url = VideoDTO.Url;
            _VideoService.Update(Video);
            return Redirect("/SysAdmin/Video/List");

        }
    }
}