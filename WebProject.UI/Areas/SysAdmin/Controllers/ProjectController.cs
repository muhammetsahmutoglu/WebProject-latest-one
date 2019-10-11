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
    public class ProjectController : Controller
    {
        UserService userService;
        ProjectService projectService;
        public ProjectController()
        {
            userService = new UserService();
            projectService = new ProjectService();
        }
        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add(Project project)
        {
            project.UserID = userService.GetByDefault(x => x.UserName == User.Identity.Name).ID;
            projectService.Add(project);
            return Redirect("/SysAdmin/Project/List");
        }

        public ActionResult Delete(int id)
        {
            Project project = projectService.GetByID(id);
            projectService.Remove(project);
            return Redirect("/SysAdmin/Project/List");
        }

        public ActionResult Update(int id)
        {
            Project project = projectService.GetByID(id);
            ProjectDTO projectDTO = new ProjectDTO()
            {
                ID = project.ID,
                Name = project.Name,
                Explanation = project.Explanation,
                ImageUrl = project.ImageUrl,
                VideoUrl = project.VideoUrl,
                StartDate = project.StartDate,
                FinishDate = project.FinishDate,                
            };
            return View(projectDTO);
        }


    }
}