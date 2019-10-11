using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.ORM.Entity;

namespace WebProject.Data.Map
{
   public class PhotoMap:BaseMap<Photo>
    {
        public PhotoMap()
        {
            ToTable("dbo.Photos");
            Property(x => x.Name).HasColumnName("Name").IsOptional();
            Property(x => x.Url).HasColumnName("Url").IsOptional();

            HasRequired(x => x.User).WithMany(x => x.Photos).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            HasRequired(x => x.PhotoCategory).WithMany(x => x.Photos).HasForeignKey(x => x.PhotoCategoryID).WillCascadeOnDelete(false);
        }
    }
}
