using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.ORM.Entity;

namespace WebProject.Data.Map
{
   public class ProjectMap:BaseMap<Project>
    {
        public ProjectMap()
        {
            ToTable("dbo.Projects");
            Property(x => x.Explanation).HasColumnName("Explanation").IsOptional();
            Property(x => x.FinishDate).HasColumnName("FinishDate").IsOptional();
            Property(x => x.ImageUrl).HasColumnName("ImageUrl").IsOptional();
            Property(x => x.Name).HasColumnName("Name").IsOptional();
            Property(x => x.StartDate).HasColumnName("Start").IsOptional();
            Property(x => x.VideoUrl).HasColumnName("VideoUrl").IsOptional();

            HasRequired(x => x.ProjectCategory).WithMany(x => x.Projects).HasForeignKey(x => x.ProjectCategoryID).WillCascadeOnDelete(false);
            HasRequired(x => x.User).WithMany(x => x.Projects).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
        }
    }
}
