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
    public class CommentController : Controller
    {
        
        UserService _UserService;
        CommentService _CommentService;
        public CommentController()
        {
            _UserService = new UserService();
            _CommentService = new CommentService();
        }
        public ActionResult Add()
        {
            Comment comment = new Comment();
            return View(comment);
        }
        [HttpPost]
        public ActionResult Add(Comment _comment, HttpPostedFileBase image)
        {
            _comment.UserID = _UserService.GetByDefault(x => x.UserName == User.Identity.Name).ID;
            _comment.ProfilePhotoURL = new byte[image.ContentLength];
            image.InputStream.Read(_comment.ProfilePhotoURL, 0, image.ContentLength);
            _CommentService.Add(_comment);
            return Redirect("/SysAdmin/Comment/List");
        }

        public ActionResult List()
        {
            List<Comment> Comments = _CommentService.GetActive().Take(12).OrderByDescending(x => x.AddDate).ToList();
            return View(Comments);
        }

        public ActionResult Delete(int id)
        {
            Comment Comment = _CommentService.GetByID(id);
            _CommentService.Remove(Comment);
            return Redirect("/SysAdmin/Comment/List");
        }

        public ActionResult Update(int id)
        {
            Comment Comment = _CommentService.GetByID(id);
            CommentDTO CommentDTO = new CommentDTO()
            {
              ID=Comment.ID,
              Authority=Comment.Authority,
              CommentContent=Comment.CommentContent,
              CompanyName=Comment.CompanyName,
              CustomerName=Comment.CustomerName,
              Email=Comment.Email,
              ProfilePhotoURL=Comment.ProfilePhotoURL,              
            };
            return View(CommentDTO);
        }
        [HttpPost]
        public ActionResult Update(CommentDTO CommentDTO)
        {

            Comment Comment = _CommentService.GetByID(CommentDTO.ID);
            Comment.ProfilePhotoURL = CommentDTO.ProfilePhotoURL;
            Comment.Authority = CommentDTO.Authority;
            Comment.Email = CommentDTO.Email;
            Comment.CommentContent = CommentDTO.CommentContent;
            Comment.CompanyName = CommentDTO.CompanyName;
            Comment.CustomerName= CommentDTO.CustomerName;            
            _CommentService.Update(Comment);
            return Redirect("/SysAdmin/Comment/List");

        }
    }
}