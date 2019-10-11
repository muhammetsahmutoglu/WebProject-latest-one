using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Data.ORM.Entity
{
   public class Project:BaseEntity
    {
        public string Name { get; set; }

        public byte[] ImageUrl { get; set; }

        public string Explanation { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public string VideoUrl { get; set; }

        public int ProjectCategoryID { get; set; }
        public virtual ProjectCategory ProjectCategory { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
