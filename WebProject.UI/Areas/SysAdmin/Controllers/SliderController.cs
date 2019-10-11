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
    public class SliderController : Controller
    {
        UserService _UserService;
        SliderService _SliderService;
        public SliderController()
        {
            _UserService = new UserService();
            _SliderService = new SliderService();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Slider _Slider)
        {
            _Slider.UserID = _UserService.GetByDefault(x => x.UserName == User.Identity.Name).ID;
            _SliderService.Add(_Slider);
            return Redirect("/SysAdmin/Slider/List");
        }

        public ActionResult List()
        {
            List<Slider> Sliders = _SliderService.GetActive().Take(12).OrderByDescending(x => x.AddDate).ToList();
            return View(Sliders);
        }

        public ActionResult Delete(int id)
        {
            Slider Slider = _SliderService.GetByID(id);
            _SliderService.Remove(Slider);
            return Redirect("/SysAdmin/Slider/List");
        }

        public ActionResult Update(int id)
        {
            Slider Slider = _SliderService.GetByID(id);
            SliderDTO SliderDTO = new SliderDTO()
            {
                ID = Slider.ID,
                Content=Slider.Content,
                Header=Slider.Header,
                ImageUrl=Slider.ImageUrl,
                Name=Slider.Name,
                SliderUrl1=Slider.SliderUrl1,
                SliderUrl2=Slider.SliderUrl2,                
            };
            return View(SliderDTO);
        }
        [HttpPost]
        public ActionResult Update(SliderDTO SliderDTO)
        {

            Slider Slider = _SliderService.GetByID(SliderDTO.ID);
            Slider.Content = SliderDTO.Content;
            Slider.Header = SliderDTO.Header;
            Slider.ImageUrl = SliderDTO.ImageUrl;
            Slider.Name = SliderDTO.Name;
            Slider.SliderUrl1 = SliderDTO.SliderUrl1;
            Slider.SliderUrl2 = SliderDTO.SliderUrl2;
            _SliderService.Update(Slider);
            return Redirect("/SysAdmin/Slider/List");

        }
    }
}