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
            Certificate certificate = new Certificate();
            return View(certificate);
        }
        [HttpPost]
        public ActionResult Add(Certificate certificate,HttpPostedFileBase image)
        {
            certificate.UserID = userService.GetByDefault(x => x.UserName == User.Identity.Name).ID;
            if (image == null)
            {
                certificateService.Add(certificate);
            }
            else
            {
                certificate.ImageURl = new byte[image.ContentLength];
                image.InputStream.Read(certificate.ImageURl, 0, image.ContentLength);
                certificateService.Add(certificate);
            }
            return Redirect("/SysAdmin/Certificate/List");
        }

        public ActionResult List()
        {
            List<Certificate> certificates = certificateService.GetActive().Take(10).OrderByDescending(x => x.AddDate).ToList();
            return View(certificates);
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
        public ActionResult Update(CertificateDTO certificateDTO, HttpPostedFileBase image)
        {
            Certificate certificate = certificateService.GetByID(certificateDTO.ID);
            certificate.Name = certificateDTO.Name;            
            certificate.Explanation = certificateDTO.Explanation;
            if (image == null)
            {
                certificateService.Update(certificate);
            }
            else
            {
                certificate.ImageURl = new byte[image.ContentLength];
                image.InputStream.Read(certificate.ImageURl, 0, image.ContentLength);
                certificateService.Update(certificate);
            }
            return Redirect("/SysAdmin/Certificate/Show" + "/" + certificate.ID);
        }
    }
}