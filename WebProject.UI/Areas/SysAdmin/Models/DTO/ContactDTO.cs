using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.UI.Areas.SysAdmin.Models.DTO
{
    public class ContactDTO
    {
        public string Content { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }


        public string Cellphone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }


        public string WorkHoursInWeekDays { get; set; }
        public string WorkHoursInWeekends { get; set; }

        public string GoogleMap { get; set; }

        public int ID { get; set; }
    }
}