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
    public class VideoController : Controller
    {
        UserService _UserService;
        VideoService _VideoService;
        public VideoController()
        {
            _UserService = new UserService();
            _VideoService = new VideoService();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Video _Video)
        {
            _Video.UserID = _UserService.GetByDefault(x => x.UserName == User.Identity.Name).ID;
            _VideoService.Add(_Video);
            return Redirect("/SysAdmin/Video/List");
        }

        public ActionResult List()
        {
            List<Video> Videos = _VideoService.GetActive().Take(12).OrderByDescending(x => x.AddDate).ToList();
            return View(Videos);
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