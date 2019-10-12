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
    public class PhotoController : Controller
    {
        UserService _UserService;
        PhotoService _PhotoService;
        PhotoCategoryService _PhotoCategoryService;
        public PhotoController()
        {
            _UserService = new UserService();
            _PhotoService = new PhotoService();
            _PhotoCategoryService = new PhotoCategoryService();
        }
        public ActionResult Add()
        {
            PhotoVM photoVM = new PhotoVM()
            {
                Categories = _PhotoCategoryService.GetActive()

            };
            return View(photoVM);
        }
        [HttpPost]
        public ActionResult Add(PhotoVM _Photo,HttpPostedFileBase image)
        {
            _Photo.Photo.UserID = _UserService.GetByDefault(x => x.UserName == User.Identity.Name).ID;
            if (image == null)
            {
                return View();
            }
            else
            {
                _Photo.Photo.Url = new byte[image.ContentLength];
                image.InputStream.Read(_Photo.Photo.Url, 0, image.ContentLength);
                _Photo.Photo.Name = image.FileName;
                _Photo.Photo.PhotoCategoryID = _PhotoCategoryService.GetByDefault(x => x.Name == _Photo.CategoryName).ID;
                image.SaveAs(image.FileName);
                _PhotoService.Add(_Photo.Photo);
            }            
            return Redirect("/SysAdmin/Photo/List");
        }

        public ActionResult List()
        {
            List<Photo> Photos = _PhotoService.GetActive().Take(12).OrderByDescending(x => x.AddDate).ToList();
            return View(Photos);
        }

        public ActionResult ListByCategory(int id)
        {
            List<Photo> photos = _PhotoService.GetActive().Where(x => x.PhotoCategoryID == id).ToList();
            return View(photos);
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