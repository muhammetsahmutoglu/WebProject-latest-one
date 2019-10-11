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
    public class CertificateController : Controller
    {
        UserService userService;
        CertificateService certificateService;
        public CertificateController()
        {
            userService = new UserService();
            certificateService = new CertificateService();
        }
        
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Certificate certificate)
        {
            certificate.UserID = userService.GetByDefault(x => x.UserName == User.Identity.Name).ID;
            certificateService.Add(certificate);
            return Redirect("/SysAdmin/Certificate/List");
        }

        public ActionResult Delete(int id)
        {
            Certificate certificate = certificateService.GetByID(id);
            certificateService.Remove(certificate);
            return Redirect("/SysAdmin/Certificate/List");
        }

        public ActionResult Show(int id)
        {
            Certificate certificate = certificateService.GetByID(id);
            return View(certificate);
        }

        public ActionResult Update(int id)
        {
            Certificate certificate = certificateService.GetByID(id);
            CertificateDTO certificateDTO = new CertificateDTO()
            {
                ID = certificate.ID,
                Name = certificate.Name,
                Explanation = certificate.Explanation,
                ImageURl = certificate.ImageURl,
            };
            return View(certificateDTO);
        }
        [HttpPost]
        public ActionResult Update(CertificateDTO certificateDTO)
        {
            Certificate certificate = certificateService.GetByID(certificateDTO.ID);
            certificate.Name = certificateDTO.Name;
            certificate.ImageURl = certificateDTO.ImageURl;
            certificate.Explanation = certificateDTO.Explanation;
            certificateService.Update(certificate);
            return Redirect("SysAdmin/Certificate/Show" + "/" + certificate.ID);
        }
    }
}