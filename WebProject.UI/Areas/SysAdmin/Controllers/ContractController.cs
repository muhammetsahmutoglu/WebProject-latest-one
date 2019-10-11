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
    public class ContractController : Controller
    {
        UserService _UserService;
        ContractService _ContractService;
        public ContractController()
        {
            _UserService = new UserService();
            _ContractService = new ContractService();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Contract _Contract)
        {
            _Contract.UserID = _UserService.GetByDefault(x => x.UserName == User.Identity.Name).ID;
            _ContractService.Add(_Contract);
            return Redirect("/SysAdmin/Contract/List");
        }

        public ActionResult List()
        {
            List<Contract> Contracts = _ContractService.GetActive().Take(12).OrderByDescending(x => x.AddDate).ToList();
            return View(Contracts);
        }

        public ActionResult Delete(int id)
        {
            Contract Contract = _ContractService.GetByID(id);
            _ContractService.Remove(Contract);
            return Redirect("/SysAdmin/Contract/List");
        }

        public ActionResult Update(int id)
        {
            Contract Contract = _ContractService.GetByID(id);
            ContractDTO ContractDTO = new ContractDTO()
            {
                ID = Contract.ID,
                ContractUrl = Contract.ContractUrl,
                Explanation = Contract.Explanation,
                Name = Contract.Name,                
            };
            return View(ContractDTO);
        }
        [HttpPost]
        public ActionResult Update(ContractDTO ContractDTO)
        {

            Contract Contract = _ContractService.GetByID(ContractDTO.ID);
            Contract.Name = ContractDTO.Name;
            Contract.ContractUrl = ContractDTO.ContractUrl;
            Contract.Explanation = ContractDTO.Explanation;
            _ContractService.Update(Contract);
            return Redirect("/SysAdmin/Contract/List");

        }
    }
}