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
    public class PhotoCategoryController : Controller
    {
        UserService _UserService;
        PhotoCategoryService _PhotoCategoryService;
        public PhotoCategoryController()
        {
            _UserService = new UserService();
            _PhotoCategoryService = new PhotoCategoryService();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(PhotoCategory _PhotoCategory)
        {
            _PhotoCategory.UserID = _UserService.GetByDefault(x => x.UserName == User.Identity.Name).ID;
            if (_PhotoCategoryService.Any(x=>x.Name.ToLower()==_PhotoCategory.Name.ToLower()))
            {
                return View();
            }
            else
            {
                _PhotoCategoryService.Add(_PhotoCategory);
                return Redirect("/SysAdmin/PhotoCategory/List");
            }
            
        }

        public ActionResult List()
        {
            List<PhotoCategory> PhotoCategorys = _PhotoCategoryService.GetActive().Take(12).OrderByDescending(x => x.AddDate).ToList();
            return View(PhotoCategorys);
        }

        public ActionResult Delete(int id)
        {
            PhotoCategory PhotoCategory = _PhotoCategoryService.GetByID(id);
            _PhotoCategoryService.Remove(PhotoCategory);
            return Redirect("/SysAdmin/PhotoCategory/List");
        }

        public ActionResult Update(int id)
        {
            PhotoCategory PhotoCategory = _PhotoCategoryService.GetByID(id);
            PhotoCategoryDTO PhotoCategoryDTO = new PhotoCategoryDTO()
            {
                ID = PhotoCategory.ID,
                Explanation=PhotoCategory.Explanation,
                Name=PhotoCategory.Name,                
            };
            return View(PhotoCategoryDTO);
        }
        [HttpPost]
        public ActionResult Update(PhotoCategoryDTO PhotoCategoryDTO)
        {

            PhotoCategory PhotoCategory = _PhotoCategoryService.GetByID(PhotoCategoryDTO.ID);
            PhotoCategory.Name = PhotoCategoryDTO.Name;
            PhotoCategory.Explanation = PhotoCategoryDTO.Explanation;
            _PhotoCategoryService.Update(PhotoCategory);
            return Redirect("/SysAdmin/PhotoCategory/List");

        }

        public ActionResult Show(int id)
        {
            PhotoCategory photoCategory = _PhotoCategoryService.GetByID(id);
            return View(photoCategory);
        }
    }
}