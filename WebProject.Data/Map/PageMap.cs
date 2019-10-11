using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.ORM.Entity;

namespace WebProject.Data.Map
{
   public class PageMap:BaseMap<Page>
    {
        public PageMap()
        {
            ToTable("dbo.Pages");
            Property(x => x.Name).HasColumnName("PageName").IsOptional();
            Property(x => x.ImageUrl).HasColumnName("ImageUrl").IsOptional();
            Property(x => x.Explanation).HasColumnName("Explanation").IsOptional();

            HasRequired(x => x.User).WithMany(x => x.Pages).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
        }
    }
}
