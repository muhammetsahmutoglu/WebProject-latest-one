using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.ORM.Entity;

namespace WebProject.Data.Map
{
   public class BranchOfficeMap:BaseMap<BranchOffice>
    {
        public BranchOfficeMap()
        {
            ToTable("dbo.BranchOffices");
            Property(x => x.Name).HasColumnName("Name").IsOptional();
            Property(x => x.ImageUrl).HasColumnName("ImageUrl").IsOptional();
            Property(x => x.Phone).HasColumnName("Phone").IsOptional();
            Property(x => x.GoogleMap).HasColumnName("GoogleMap").IsOptional();
            Property(x => x.Fax).HasColumnName("Fax").IsOptional();
            Property(x => x.Email).HasColumnName("Email").IsOptional();
            Property(x => x.Adress).HasColumnName("Adress").IsOptional();


            HasRequired(x => x.User).WithMany(x => x.BranchOffices).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
        }
    }
}
