using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.ORM.Entity;


namespace WebProject.Data.Map
{
    public class BaseMap<T> : EntityTypeConfiguration<T> where T:BaseEntity
    {
        //Fluent API'ye bakınız
        public BaseMap()
        {
            Property(x => x.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.AddDate).HasColumnName("AddDate").IsOptional();
            Property(x => x.DeleteDate).HasColumnName("DeleteDate").IsOptional();
            Property(x => x.Status).HasColumnName("Status").IsOptional();
            Property(x => x.UpdateDate).HasColumnName("UpdateDate").IsOptional();


        }
    }
}
