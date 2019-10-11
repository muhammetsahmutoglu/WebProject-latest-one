using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Data.ORM.Entity
{
   public class Service:BaseEntity
    {
        public string Name { get; set; }
        public string Explanation { get; set; }
        public byte[] ImageUrl { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
