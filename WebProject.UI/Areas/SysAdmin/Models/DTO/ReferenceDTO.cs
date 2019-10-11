using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.UI.Areas.SysAdmin.Models.DTO
{
    public class ReferenceDTO
    {
        public string Name { get; set; }
        public string Explanation { get; set; }
        public byte[] LogoPath { get; set; }
        public string Link { get; set; }

        public int UserID { get; set; }
        public int ID { get; set; }
    }
}