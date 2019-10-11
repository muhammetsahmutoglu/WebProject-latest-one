using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.ORM.Entity;

namespace WebProject.Data.Map
{
  public  class PhotoCategoryMap:BaseMap<PhotoCategory>
    {
        public PhotoCategoryMap()
        {
            ToTable("dbo.PhotoCategories");
            Property(x => x.Name).HasColumnName("Name").IsOptional();
            Property(x => x.Explanation).HasColumnName("Explanation").IsOptional();
            

            HasRequired(x => x.User).WithMany(x => x.PhotoCategories).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            HasMany(x => x.Photos).WithRequired(x => x.PhotoCategory).HasForeignKey(x => x.PhotoCategoryID).WillCascadeOnDelete(false);
            
        }
    }
}
