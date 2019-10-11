using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Data.ORM.Entity
{
   public class PhotoCategory:BaseEntity
    {
        public string Name { get; set; }
        public string Explanation { get; set; }

        public virtual List<Photo> Photos { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
