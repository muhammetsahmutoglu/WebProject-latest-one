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
    public class ProjectCategoryController : Controller
    {
        UserService _UserService;
        ProjectCategoryService _ProjectCategoryService;
        public ProjectCategoryController()
        {
            _UserService = new UserService();
            _ProjectCategoryService = new ProjectCategoryService();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(ProjectCategory _ProjectCategory)
        {
            _ProjectCategory.UserID = _UserService.GetByDefault(x => x.UserName == User.Identity.Name).ID;
            _ProjectCategoryService.Add(_ProjectCategory);
            return Redirect("/SysAdmin/ProjectCategory/List");
        }

        public ActionResult List()
        {
            List<ProjectCategory> ProjectCategorys = _ProjectCategoryService.GetActive().Take(12).OrderByDescending(x => x.AddDate).ToList();
            return View(ProjectCategorys);
        }

        public ActionResult Delete(int id)
        {
            ProjectCategory ProjectCategory = _ProjectCategoryService.GetByID(id);
            _ProjectCategoryService.Remove(ProjectCategory);
            return Redirect("/SysAdmin/ProjectCategory/List");
        }

        public ActionResult Update(int id)
        {
            ProjectCategory ProjectCategory = _ProjectCategoryService.GetByID(id);
            ProjectCategoryDTO ProjectCategoryDTO = new ProjectCategoryDTO()
            {
                ID = ProjectCategory.ID,
                Explanation = ProjectCategory.Explanation,
                Name = ProjectCategory.Name,
            };
            return View(ProjectCategoryDTO);
        }
        [HttpPost]
        public ActionResult Update(ProjectCategoryDTO ProjectCategoryDTO)
        {

            ProjectCategory ProjectCategory = _ProjectCategoryService.GetByID(ProjectCategoryDTO.ID);
            ProjectCategory.Name = ProjectCategoryDTO.Name;
            ProjectCategory.Explanation = ProjectCategoryDTO.Explanation;
            _ProjectCategoryService.Update(ProjectCategory);
            return Redirect("/SysAdmin/ProjectCategory/List");

        }
      
    }
}