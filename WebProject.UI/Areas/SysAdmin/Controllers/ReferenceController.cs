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
    public class ReferenceController : Controller
    {
        UserService _UserService;
        ReferrenceService _ReferenceService;
        public ReferenceController()
        {
            _UserService = new UserService();
            _ReferenceService = new ReferrenceService();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Reference _Reference)
        {
            _Reference.UserID = _UserService.GetByDefault(x => x.UserName == User.Identity.Name).ID;
            _ReferenceService.Add(_Reference);
            return Redirect("/SysAdmin/Reference/List");
        }

        public ActionResult List()
        {
            List<Reference> References = _ReferenceService.GetActive().Take(12).OrderByDescending(x => x.AddDate).ToList();
            return View(References);
        }

        public ActionResult Delete(int id)
        {
            Reference Reference = _ReferenceService.GetByID(id);
            _ReferenceService.Remove(Reference);
            return Redirect("/SysAdmin/Reference/List");
        }

        public ActionResult Update(int id)
        {
            Reference Reference = _ReferenceService.GetByID(id);
            ReferenceDTO ReferenceDTO = new ReferenceDTO()
            {
                ID = Reference.ID,
                Explanation = Reference.Explanation,
                Name = Reference.Name,
                Link=Reference.Link,
                LogoPath=Reference.LogoPath,
                
            };
            return View(ReferenceDTO);
        }
        [HttpPost]
        public ActionResult Update(ReferenceDTO ReferenceDTO)
        {

            Reference Reference = _ReferenceService.GetByID(ReferenceDTO.ID);
            Reference.Name = ReferenceDTO.Name;
            Reference.Explanation = ReferenceDTO.Explanation;
            Reference.Link = ReferenceDTO.Link;
            Reference.LogoPath = ReferenceDTO.LogoPath;
            _ReferenceService.Update(Reference);
            return Redirect("/SysAdmin/Reference/List");

        }
    }
}