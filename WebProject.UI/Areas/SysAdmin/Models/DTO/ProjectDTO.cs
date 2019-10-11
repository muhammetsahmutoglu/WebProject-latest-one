using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.UI.Areas.SysAdmin.Models.DTO
{
    public class ProjectDTO
    {
        public string Name { get; set; }

        public byte[] ImageUrl { get; set; }

        public string Explanation { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public string VideoUrl { get; set; }

        public int ProjectCategoryID { get; set; }
        

        public int UserID { get; set; }
        public int ID { get; set; }
    }
}