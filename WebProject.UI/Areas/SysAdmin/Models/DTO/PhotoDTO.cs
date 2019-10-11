using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.UI.Areas.SysAdmin.Models.DTO
{
    public class PhotoDTO
    {
        public string Name { get; set; }
        public byte[] Url { get; set; }

        public int PhotoCategoryID { get; set; }      

        public int UserID { get; set; }

        public int ID { get; set; }
    }
}