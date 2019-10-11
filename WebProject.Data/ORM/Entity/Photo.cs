using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Data.ORM.Entity
{
   public class Photo:BaseEntity
    {//Foto galeri..
        public string Name { get; set; }
        public byte[] Url { get; set; }

        public int PhotoCategoryID { get; set; }
        public virtual PhotoCategory PhotoCategory { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
