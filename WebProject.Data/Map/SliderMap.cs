using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.ORM.Entity;

namespace WebProject.Data.Map
{
   public class SliderMap:BaseMap<Slider>
    {
        public SliderMap()
        {
            ToTable("dbo.Sliders");

            Property(x => x.Content).HasColumnName("Content").IsOptional();
            Property(x => x.Header).HasColumnName("Header").IsOptional();
            Property(x => x.ImageUrl).HasColumnName("ImageUrl").IsOptional();
            Property(x => x.Name).HasColumnName("Name").IsOptional();
            Property(x => x.SliderUrl1).HasColumnName("SliderUrl1").IsOptional();
            Property(x => x.SliderUrl2).HasColumnName("SliderUrl2").IsOptional();

            HasRequired(x => x.User).WithMany(x => x.Sliders).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
        }
    }
}
