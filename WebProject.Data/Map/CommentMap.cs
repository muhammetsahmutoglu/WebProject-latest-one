using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.ORM.Entity;

namespace WebProject.Data.Map
{
   public class CommentMap:BaseMap<Comment>
    {
        public CommentMap()
        {
            ToTable("dbo.Comments");
            Property(x => x.ProfilePhotoURL).HasColumnName("ProfilePhotoUrl").IsOptional();
            Property(x => x.Authority).HasColumnName("Authority").IsOptional();
            Property(x => x.CommentContent).HasColumnName("CommentContent").IsOptional();
            Property(x=>x.CompanyName).HasColumnName("CompanyName").IsOptional();
            Property(x=>x.CustomerName).HasColumnName("CustomerName").IsOptional();
            Property(x => x.Email).HasColumnName("Email").IsOptional();

            HasRequired(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
        }
    }
}
