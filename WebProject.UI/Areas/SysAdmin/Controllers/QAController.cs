using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.BLL.Option;
using WebProject.Data.ORM.Entity;
using WebProject.UI.Areas.SysAdmin.Models.VM;

namespace WebProject.UI.Areas.SysAdmin.Controllers
{
    public class QAController : Controller
    {//<sıkça sorulan sorular ve cevaplar için controller
        UserService userService;
        QuestionService questionService;
        AnswerService answerService;
        public QAController()
        {
            userService = new UserService();
            questionService = new QuestionService();
            answerService = new AnswerService();
        }
        public ActionResult Add()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Add(QuestionAnswerVM data)
        {
            Question question = new Question
            {
                Content = data.Content
            };
            User user = userService.GetByDefault(x => x.UserName == User.Identity.Name);            
            question.UserID = user.ID;
            questionService.Add(question);

            Answer answer = new Answer
            {
                QuestionID = question.ID,
                UserID = user.ID,
                Content = data.AnswerContent
            };
            answerService.Add(answer);
            return Redirect("/SysAdmin/QA/List");
        }

        public ActionResult List()
        {
            QAVM model = new QAVM()
            {
                Questions = questionService.GetActive().Take(10).OrderByDescending(x => x.AddDate).ToList(),
                Answers = answerService.GetActive().Take(10).OrderByDescending(x => x.AddDate).ToList(),
            };
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            Answer answer = answerService.GetByID(id);
            Question question = questionService.GetByID(answer.QuestionID);
            answerService.Remove(answer);
            questionService.Remove(question);
            return Redirect("/SysAdmin/QA/List");
        }

        public ActionResult Update(int id)
        {//
            Answer answer = answerService.GetByID(id);
            Question question = questionService.GetByID(answer.QuestionID);
            QuestionAnswerVM model = new QuestionAnswerVM()
            {
                Content = question.Content,
                AnswerContent = answer.Content,
                UserID = userService.GetByDefault(x => x.UserName == User.Identity.Name).ID,
                AnswerID=answer.ID,
                QuestionID=question.ID
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(QuestionAnswerVM data)
        {
            Answer answer = answerService.GetByID(data.AnswerID);
            answer.Content = data.AnswerContent;
            //answer.UserID = data.UserID;
            answer.Status = Data.ORM.Enum.Status.Updated;
            Question question = questionService.GetByID(data.QuestionID);
            question.Content = data.Content;
            //question.UserID = data.UserID;
            question.Status = Data.ORM.Enum.Status.Updated;
            questionService.Update(question);
            answerService.Update(answer);
            return Redirect("/SysAdmin/QA/List");
        }
    }
}