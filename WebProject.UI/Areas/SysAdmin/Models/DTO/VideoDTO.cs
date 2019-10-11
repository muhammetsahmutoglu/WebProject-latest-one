using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.UI.Areas.SysAdmin.Models.DTO
{
    public class VideoDTO
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public int VideoCategoryID { get; set; }
        

        public int UserID { get; set; }
        public int ID { get; set; }
    }
}