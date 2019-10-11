using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.ORM.Entity;

namespace WebProject.Data.Map
{
   public class CertificateMap:BaseMap<Certificate>
    {
        public CertificateMap()
        {
            ToTable("dbo.Certificates");
            Property(x => x.Explanation).HasColumnName("Explanation").IsOptional();
            Property(x => x.ImageURl).HasColumnName("ImageUrl").IsOptional();
            Property(x => x.Name).HasColumnName("Name").IsOptional();

            HasRequired(x => x.User).WithMany(x => x.Certificates).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            
        }
    }
}
