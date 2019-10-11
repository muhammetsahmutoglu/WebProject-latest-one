using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProject.Data.ORM.Entity;

namespace WebProject.UI.Areas.SysAdmin.Models.VM
{
    public class QAVM
    {
        public QAVM()
        {
            Questions = new List<Question>();
            Answers = new List<Answer>();
        }
        public List<Question> Questions { get; set; }
        public List<Answer> Answers { get; set; }
    }
}