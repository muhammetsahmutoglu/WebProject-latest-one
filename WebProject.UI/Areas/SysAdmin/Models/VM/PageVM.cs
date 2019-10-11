using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProject.Data.ORM.Entity;

namespace WebProject.UI.Areas.SysAdmin.Models.VM
{//
    public class PageVM
    {
        public PageVM()
        {
            page = new Page();
            pages = new List<Page>();
        }
        public Page page { get; set; }
        public List<Page> pages { get; set; }
    }
}