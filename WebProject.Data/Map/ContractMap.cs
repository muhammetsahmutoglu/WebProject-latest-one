using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.ORM.Entity;

namespace WebProject.Data.Map
{
    public class ContractMap : BaseMap<Contract>
    {
        public ContractMap()
        {
            ToTable("dbo.Contracts");
            Property(x => x.Name).HasColumnName("Name").IsOptional();
            Property(x => x.Explanation).HasColumnName("Explanation").IsOptional();
            Property(x => x.ContractUrl).HasColumnName("ContractUrl").IsOptional();

            HasRequired(x => x.User).WithMany(x => x.Contracts).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
        }
    }
}
