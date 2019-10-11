using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.BLL.Option;
using WebProject.Data.ORM.Entity;
using WebProject.UI.Areas.SysAdmin.Models.DTO;

namespace WebProject.UI.Areas.SysAdmin.Controllers
{
    public class CatalogController : Controller
    {
        UserService userService;
        CatalogService catalogService;
        public CatalogController()
        {
            userService = new UserService();
            catalogService = new CatalogService();
        }
        public ActionResult Add()
        {
            Catalog catalog = new Catalog();
            return View(catalog);
        }
        [HttpPost]
        public ActionResult Add(Catalog catalog, HttpPostedFileBase image)
        {
            catalog.UserID = userService.GetByDefault(x => x.UserName == User.Identity.Name).ID;            
            catalog.ImageUrl = new byte[image.ContentLength];
            image.InputStream.Read(catalog.ImageUrl, 0, image.ContentLength);
            catalogService.Add(catalog);
            return Redirect("/SysAdmin/Catalog/List");
        }

        public ActionResult List()
        {
            List<Catalog> catalogs = catalogService.GetActive().Take(10).OrderByDescending(x => x.AddDate).ToList();
            return View(catalogs);
        }

        public ActionResult Delete(int id)
        {
            Catalog catalog = catalogService.GetByID(id);
            catalogService.Remove(catalog);
            return Redirect("/SysAdmin/Catalog/List");
        }

        public ActionResult Update(int id)
        {
            Catalog catalog = catalogService.GetByID(id);
            CatalogDTO catalogDTO = new CatalogDTO()
            {
                Name=catalog.Name,
                Explanation=catalog.Explanation,
                ImageUrl=catalog.ImageUrl,
                ID=catalog.ID
            };
            return View(catalogDTO);
        }
        [HttpPost]
        public ActionResult Update(CatalogDTO catalogDTO)
        {
            Catalog catalog = catalogService.GetByID(catalogDTO.ID);
            catalog.Explanation = catalogDTO.Explanation;
            catalog.Name = catalogDTO.Name;
            catalog.ImageUrl = catalogDTO.ImageUrl;
            catalogService.Update(catalog);
            return Redirect("/SysAdmin/Catalog/List");
        }
    }
}