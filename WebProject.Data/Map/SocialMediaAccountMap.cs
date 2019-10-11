using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.ORM.Entity;

namespace WebProject.Data.Map
{
   public class SocialMediaAccountMap:BaseMap<SocialMediaAccount>
    {
        public SocialMediaAccountMap()
        {
            ToTable("dbo.SocialMediaAccounts");
            Property(x => x.Name).HasColumnName("Name").IsOptional();
            Property(x => x.Url).HasColumnName("Url").IsOptional();
            HasRequired(x => x.User).WithMany(x => x.SocialMediaAccounts).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
        }
    }
}
