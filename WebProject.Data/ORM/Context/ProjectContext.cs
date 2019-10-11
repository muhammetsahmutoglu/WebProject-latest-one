using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.Map;
using WebProject.Data.ORM.Entity;

namespace WebProject.Data.ORM.Context
{

    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "Server=MONSTER;Database=WebProject;Integrated Security=True;";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new AnsweMap());
            modelBuilder.Configurations.Add(new CatalogMap());
            modelBuilder.Configurations.Add(new CertificateMap());
            modelBuilder.Configurations.Add(new ContactMap());
            modelBuilder.Configurations.Add(new ContractMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new ReferrenceMap());
            modelBuilder.Configurations.Add(new PageMap());
            modelBuilder.Configurations.Add(new BranchOfficeMap());
            modelBuilder.Configurations.Add(new PhotoCategoryMap());
            modelBuilder.Configurations.Add(new PhotoMap());
            modelBuilder.Configurations.Add(new ProjectCategoryMap());
            modelBuilder.Configurations.Add(new ProjectMap());
            modelBuilder.Configurations.Add(new ServiceMap());
            modelBuilder.Configurations.Add(new SliderMap());
            modelBuilder.Configurations.Add(new SocialMediaAccountMap());
            modelBuilder.Configurations.Add(new VideoMap());
            modelBuilder.Configurations.Add(new VideoCategoryMap());


            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BranchOffice> BranchOffices { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<PhotoCategory> PhotoCategories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SocialMediaAccount> SocialMediaAccounts { get; set; }
        public DbSet<Video> Videos{ get; set; }
        public DbSet<VideoCategory> VideoCategories { get; set; }

    }
}
