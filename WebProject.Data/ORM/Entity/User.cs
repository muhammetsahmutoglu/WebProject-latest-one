using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Data.ORM.Entity
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] ProfilePhoto { get; set; }



        public virtual List<Question> Questions { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Page> Pages { get; set; }

        public virtual List<Reference> References { get; set; }

        public virtual List<Certificate> Certificates { get; set; }

        public virtual List<Catalog> Catalogs { get; set; }
        public virtual List<Contract> Contracts { get; set; }

        public virtual List<SocialMediaAccount> SocialMediaAccounts { get; set; }

        public virtual List<BranchOffice> BranchOffices { get; set; }
        public virtual List<Service> Services { get; set; }

        public virtual List<Photo> Photos  { get; set; }
        public virtual List<PhotoCategory> PhotoCategories { get; set; }

        public virtual List<Video> Videos { get; set; }
        public virtual List<VideoCategory> VideoCategories { get; set; }

        public virtual List<Slider> Sliders { get; set; }
        public virtual List<Project> Projects { get; set; }
        public virtual List<ProjectCategory> ProjectCategories { get; set; }


    }
}
