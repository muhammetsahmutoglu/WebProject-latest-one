using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.ORM.Entity;

namespace WebProject.Data.Map
{
   public class ReferrenceMap:BaseMap<Reference>
    {
        public ReferrenceMap()
        {
            ToTable("dbo.Referrences");

            Property(x => x.Link).HasColumnName("Link").IsOptional();
            Property(x => x.LogoPath).HasColumnName("LogoPath").IsOptional();
            Property(x => x.Name).HasColumnName("Name").IsOptional();
            Property(x => x.Explanation).HasColumnName("Explanation").IsOptional();

            HasRequired(x => x.User).WithMany(x => x.References).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
        }
    }
}
