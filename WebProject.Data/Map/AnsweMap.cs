using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.ORM.Entity;

namespace WebProject.Data.Map
{
   public class AnsweMap:BaseMap<Answer>
    {
        public AnsweMap()
        {
            ToTable("dbo.Answers");
            Property(x => x.Content).HasColumnName("Content").IsOptional();

            HasRequired(x => x.Question).WithMany(x => x.Answers).HasForeignKey(x => x.QuestionID);
            HasRequired(x => x.User).WithMany(x => x.Answers).HasForeignKey(x => x.UserID);
        }
    }
}
