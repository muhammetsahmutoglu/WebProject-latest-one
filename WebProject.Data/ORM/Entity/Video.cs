﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Data.ORM.Entity
{
   public class Video:BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public int VideoCategoryID { get; set; }
        public virtual VideoCategory VideoCategory { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
