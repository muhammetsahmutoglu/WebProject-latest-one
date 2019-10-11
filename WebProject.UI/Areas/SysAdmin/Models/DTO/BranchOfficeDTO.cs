using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.UI.Areas.SysAdmin.Models.DTO
{
    public class BranchOfficeDTO
    {//
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }

        public byte[] ImageUrl { get; set; }

        public string GoogleMap { get; set; }

        public int UserID { get; set; }
        public int ID { get; set; }
    }
}