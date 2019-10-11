using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.UI.Areas.SysAdmin.Controllers
{
    public class SysController : Controller
    {
        // GET: SysAdmin/Sys
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}