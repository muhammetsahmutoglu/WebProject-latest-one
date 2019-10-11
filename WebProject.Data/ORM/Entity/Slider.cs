using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Data.ORM.Entity
{
   public class Slider:BaseEntity
    {
        public string Name { get; set; }
        public byte[] ImageUrl { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }

        public byte[] SliderUrl1 { get; set; }
        public byte[] SliderUrl2 { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }


    }
}
