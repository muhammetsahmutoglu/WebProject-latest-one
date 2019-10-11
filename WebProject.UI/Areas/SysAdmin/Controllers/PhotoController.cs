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
    public class PhotoController : Controller
    {
        UserService _UserService;
        PhotoService _PhotoService;
        public PhotoController()
        {
            _UserService = new UserService();
            _PhotoService = new PhotoService();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Photo _Photo)
        {
            _Photo.UserID = _UserService.GetByDefault(x => x.UserName == User.Identity.Name).ID;
            _PhotoService.Add(_Photo);
            return Redirect("/SysAdmin/Photo/List");
        }

        public ActionResult List()
        {
            List<Photo> Photos = _PhotoService.GetActive().Take(12).OrderByDescending(x => x.AddDate).ToList();
            return View(Photos);
        }

        public ActionResult Delete(int id)
        {
            Photo Photo = _PhotoService.GetByID(id);
            _PhotoService.Remove(Photo);
            return Redirect("/SysAdmin/Photo/List");
        }

        public ActionResult Update(int id)
        {
            Photo Photo = _PhotoService.GetByID(id);
            PhotoDTO PhotoDTO = new PhotoDTO()
            {
                ID = Photo.ID,
                Name = Photo.Name,
                Url=Photo.Url,
                 
            };
            return View(PhotoDTO);
        }
        [HttpPost]
        public ActionResult Update(PhotoDTO PhotoDTO)
        {

            Photo Photo = _PhotoService.GetByID(PhotoDTO.ID);
            Photo.ID = PhotoDTO.ID;
            Photo.Name = PhotoDTO.Name;
            Photo.Url = PhotoDTO.Url;
            _PhotoService.Update(Photo);
            return Redirect("/SysAdmin/Photo/List");

        }
    }
}