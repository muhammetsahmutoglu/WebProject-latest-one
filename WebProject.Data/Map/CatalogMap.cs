using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.ORM.Entity;

namespace WebProject.Data.Map
{
   public class CatalogMap:BaseMap<Catalog>
    {
        public CatalogMap()
        {
            ToTable("dbo.Catalogs");
            Property(x => x.Name).HasColumnName("Name").IsOptional();
            Property(x => x.Explanation).HasColumnName("Explanation").IsOptional();
            Property(x => x.ImageUrl).HasColumnName("ImageUrl").IsOptional();

            HasRequired(x => x.User).WithMany(x => x.Catalogs).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
        }
    }
}
