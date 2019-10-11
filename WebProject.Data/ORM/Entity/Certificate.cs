using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Data.ORM.Entity
{
    public class Certificate : BaseEntity
    {
        public string Name { get; set; }
        public byte[] ImageURl { get; set; }
        public string Explanation  { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
