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
    public class ContactController : Controller
    {
        UserService _UserService;
        ContactService _ContactService;
        public ContactController()
        {
            _UserService = new UserService();
            _ContactService = new ContactService();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Contact _Contact)
        {            
            _ContactService.Add(_Contact);
            return Redirect("/SysAdmin/Contact/List");
        }

        public ActionResult List()
        {
            List<Contact> Contacts = _ContactService.GetActive().Take(12).OrderByDescending(x => x.AddDate).ToList();
            return View(Contacts);
        }

        public ActionResult Delete(int id)
        {
            Contact Contact = _ContactService.GetByID(id);
            _ContactService.Remove(Contact);
            return Redirect("/SysAdmin/Contact/List");
        }

        public ActionResult Update(int id)
        {
            Contact Contact = _ContactService.GetByID(id);
            ContactDTO ContactDTO = new ContactDTO()
            {
                ID = Contact.ID,
                Adress=Contact.Adress,
                Cellphone= Contact.Cellphone,
                Content= Contact.Content,
                Email= Contact.Email,
                Fax= Contact.Fax,
                GoogleMap= Contact.GoogleMap,
                PhoneNumber= Contact.PhoneNumber,
                WorkHoursInWeekDays= Contact.WorkHoursInWeekDays,
                WorkHoursInWeekends= Contact.WorkHoursInWeekends
            };
            return View(ContactDTO);
        }
        [HttpPost]
        public ActionResult Update(ContactDTO ContactDTO)
        {

            Contact Contact = _ContactService.GetByID(ContactDTO.ID);
            Contact.Adress = ContactDTO.Adress;
            Contact.Cellphone = ContactDTO.Cellphone;
            Contact.Content = ContactDTO.Content;
            Contact.Email = ContactDTO.Email;
            Contact.Fax = ContactDTO.Fax;
            Contact.GoogleMap = ContactDTO.GoogleMap;
            Contact.PhoneNumber = ContactDTO.PhoneNumber;
            Contact.WorkHoursInWeekDays = ContactDTO.WorkHoursInWeekDays;
            Contact.WorkHoursInWeekends = ContactDTO.WorkHoursInWeekends;
               _ContactService.Update(Contact);
               return Redirect("/SysAdmin/Contact/List");

        }
    }
}