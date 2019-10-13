using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProject.Data.ORM.Entity;

namespace WebProject.UI.Areas.SysAdmin.Models.VM
{
    public class PhotoVM
    {
        public PhotoVM()
        {
            Photo = new Photo();
            Photos = new List<Photo>();            
            Categories = new List<PhotoCategory>();
        }
        public Photo Photo { get; set; }
        public List<PhotoCategory> Categories { get; set; }
        public string CategoryName { get; set; }
        public string UserName { get; set; }
        public List<Photo> Photos { get; set; }
        
    }
}