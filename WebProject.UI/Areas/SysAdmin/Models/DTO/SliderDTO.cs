using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.UI.Areas.SysAdmin.Models.DTO
{
    public class SliderDTO
    {
        public string Name { get; set; }
        public byte[] ImageUrl { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }

        public byte[] SliderUrl1 { get; set; }
        public byte[] SliderUrl2 { get; set; }

        public int UserID { get; set; }
        public int ID { get; set; }
    }
}