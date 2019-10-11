using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.ORM.Entity;

namespace WebProject.Data.Map
{
   public class ProjectCategoryMap:BaseMap<ProjectCategory>
    {
        public ProjectCategoryMap()
        {
            ToTable("dbo.ProjectCategories");
            Property(x => x.Explanation).HasColumnName("Explanation").IsOptional();
            Property(x => x.Name).HasColumnName("Name").IsOptional();

            HasRequired(x => x.User).WithMany(x => x.ProjectCategories).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            HasMany(x => x.Projects).WithRequired(x => x.ProjectCategory).HasForeignKey(x => x.ProjectCategoryID).WillCascadeOnDelete(false);
        }
    }
}
