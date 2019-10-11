using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.ORM.Entity;

namespace WebProject.Data.Map
{
  public  class VideoCategoryMap:BaseMap<VideoCategory>
    {
        public VideoCategoryMap()
        {
            ToTable("dbo.VideoCategories");
            Property(x => x.Name).HasColumnName("Name").IsOptional();
            Property(x => x.Explanation).HasColumnName("Explanation").IsOptional();

            HasMany(x => x.Videos).WithRequired(x => x.VideoCategory).HasForeignKey(x => x.VideoCategoryID).WillCascadeOnDelete(false);
            HasRequired(x => x.User).WithMany(x => x.VideoCategories).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
        }
    }
}
