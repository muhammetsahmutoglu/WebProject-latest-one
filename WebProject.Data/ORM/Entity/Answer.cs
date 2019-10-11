using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Data.ORM.Entity
{
    public class Answer : BaseEntity
    {
        public string Content { get; set; }


        public int UserID { get; set; }
        public virtual User User { get; set; }

        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }
    }
}
