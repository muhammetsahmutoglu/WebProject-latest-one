using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.ORM.Entity;

namespace WebProject.Data.Map
{
   public class ServiceMap:BaseMap<Service>
    {
        public ServiceMap()
        {
            ToTable("dbo.Services");
            Property(x => x.Explanation).HasColumnName("Explanation").IsOptional();
            Property(x => x.ImageUrl).HasColumnName("ImageUrl").IsOptional();
            Property(x => x.Name).HasColumnName("Name").IsOptional();


            HasRequired(x => x.User).WithMany(x => x.Services).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
        }
    }
}
