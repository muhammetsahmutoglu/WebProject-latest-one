using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProject.Data.ORM.Entity;

namespace WebProject.UI.Areas.SysAdmin.Models.VM
{
    public class QuestionAnswerVM
    {
        public string Content { get; set; }
        public string AnswerContent { get; set; }
        public int UserID { get; set; }
        public int AnswerID { get; set; }
        public int QuestionID { get; set; }

    }
}