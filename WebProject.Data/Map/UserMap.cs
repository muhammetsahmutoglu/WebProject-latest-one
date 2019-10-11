using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.ORM.Entity;

namespace WebProject.Data.Map
{
   public class UserMap:BaseMap<User>
    {
        public UserMap()
        {
            ToTable("dbo.Users");
            Property(x => x.FirstName).HasColumnName("FirstName").IsOptional();
            Property(x => x.LastName).HasColumnName("LastName").IsOptional();
            Property(x => x.Email).HasColumnName("Email").IsOptional();
            Property(x => x.Password).HasColumnName("Password").IsOptional();
            Property(x => x.IsAdmin).HasColumnName("isAdmin").IsOptional();
            Property(x => x.ProfilePhoto).HasColumnName("ProfilePhoto").IsOptional();

            HasMany(x => x.Answers).WithRequired(x => x.User).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            HasMany(x => x.Questions).WithRequired(x => x.User).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            HasMany(x=>x.Comments).WithRequired(x=>x.User).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            HasMany(x => x.Pages).WithRequired(x => x.User).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            HasMany(x => x.References).WithRequired(x => x.User).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            HasMany(x=>x.Catalogs).WithRequired(x=>x.User).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            HasMany(x=>x.Certificates).WithRequired(x => x.User).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            HasMany(x=>x.Contracts).WithRequired(x => x.User).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            HasMany(x => x.SocialMediaAccounts).WithRequired(x => x.User).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            HasMany(x => x.BranchOffices).WithRequired(x => x.User).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            HasMany(x=>x.Services).WithRequired(x=>x.User).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            HasMany(x => x.Photos).WithRequired(x => x.User).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            HasMany(x=>x.PhotoCategories).WithRequired(x => x.User).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            HasMany(x=>x.Videos).WithRequired(x => x.User).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            HasMany(x=>x.VideoCategories).WithRequired(x => x.User).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            HasMany(x => x.Sliders).WithRequired(x => x.User).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            HasMany(x => x.Projects).WithRequired(x => x.User).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            HasMany(x => x.ProjectCategories).WithRequired(x => x.User).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            
        }
        
    }
}
