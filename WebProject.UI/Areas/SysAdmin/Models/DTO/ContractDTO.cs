using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.UI.Areas.SysAdmin.Models.DTO
{
    public class ContractDTO
    {
        public string Name { get; set; }
        public string Explanation { get; set; }

        public string ContractUrl { get; set; }

        public int ID { get; set; }
    }
}