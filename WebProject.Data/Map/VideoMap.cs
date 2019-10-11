using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.ORM.Entity;

namespace WebProject.Data.Map
{
   public class VideoMap:BaseMap<Video>
    {
        public VideoMap()
        {//
            ToTable("dbo.Videos");
            Property(x => x.Name).HasColumnName("Name").IsOptional();
            Property(x => x.Url).HasColumnName("Url").IsOptional();

            HasRequired(x => x.User).WithMany(x => x.Videos).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            HasRequired(x => x.VideoCategory).WithMany(x => x.Videos).HasForeignKey(x => x.VideoCategoryID).WillCascadeOnDelete(false);
        }
    }
}
