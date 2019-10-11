using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.ORM.Entity;

namespace WebProject.Data.Map
{
   public class QuestionMap:BaseMap<Question>
    {
        public QuestionMap()
        {
            ToTable("dbo.Questions");

            Property(x => x.Content).HasColumnName("Content").IsOptional();

            HasRequired(x => x.User).WithMany(x => x.Questions).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);

            HasMany(x => x.Answers).WithRequired(x => x.Question).HasForeignKey(x => x.QuestionID).WillCascadeOnDelete(false);
        }
    }
}
