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
    public class BranchOfficeController : Controller
    {
        UserService userService;
        BranchOfficeService branchOfficeService; 
        public BranchOfficeController()
        {
            userService = new UserService();
            branchOfficeService = new BranchOfficeService();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(BranchOffice branchOffice)
        {
            branchOffice.UserID = userService.GetByDefault(x => x.UserName == User.Identity.Name).ID;
            branchOfficeService.Add(branchOffice);
            return Redirect("/SysAdmin/BranchOffice/List");
        }

        public ActionResult List()
        {
            List<BranchOffice> branchOffices = branchOfficeService.GetActive().Take(12).OrderByDescending(x=>x.AddDate).ToList();
            return View(branchOffices);
        }

        public ActionResult Delete(int id)
        {
            BranchOffice branchOffice = branchOfficeService.GetByID(id);
            branchOfficeService.Remove(branchOffice);
            return Redirect("/SysAdmin/BranchOffice/List");
        }

        public ActionResult Update(int id)
        {
            BranchOffice branchOffice = branchOfficeService.GetByID(id);
            BranchOfficeDTO branchOfficeDTO = new BranchOfficeDTO()
            {
                Name=branchOffice.Name,
                Adress=branchOffice.Adress,
                Email=branchOffice.Email,
                Fax=branchOffice.Fax,
                GoogleMap=branchOffice.GoogleMap,
                ImageUrl=branchOffice.ImageUrl,
                UserID=branchOffice.UserID,
                Phone=branchOffice.Phone,
                ID=branchOffice.ID
            };
            return View(branchOfficeDTO);
        }
        [HttpPost]
        public ActionResult Update(BranchOfficeDTO branchOfficeDTO)
        {

            BranchOffice branchOffice = branchOfficeService.GetByID(branchOfficeDTO.ID);
            branchOffice.Name = branchOfficeDTO.Name;
            branchOffice.Adress = branchOfficeDTO.Adress;
            branchOffice.Email = branchOfficeDTO.Email;
            branchOffice.Fax = branchOfficeDTO.Fax;
            branchOffice.GoogleMap = branchOfficeDTO.GoogleMap;
            branchOffice.ImageUrl = branchOfficeDTO.ImageUrl;
            branchOffice.Phone = branchOfficeDTO.Phone;
            branchOfficeService.Update(branchOffice);
            return Redirect("/SysAdmin/BranchOffice/List");

        }

    }
}