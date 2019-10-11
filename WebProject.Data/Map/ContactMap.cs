using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.ORM.Entity;

namespace WebProject.Data.Map
{
   public class ContactMap:BaseMap<Contact>
    {
        public ContactMap()
        {
            ToTable("dbo.Contacts");

            Property(x => x.Adress).HasColumnName("Adress").IsOptional();
            Property(x => x.Cellphone).HasColumnName("Cellphone").IsOptional();
            Property(x => x.Content).HasColumnName("Content").IsOptional();
            Property(x => x.Email).HasColumnName("Email").IsOptional();
            Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").IsOptional();
            Property(x => x.WorkHoursInWeekDays).HasColumnName("WorkHoursInWeekDays").IsOptional();
            Property(x => x.WorkHoursInWeekends).HasColumnName("WorkHoursInWeekends").IsOptional();
            Property(x => x.Fax).HasColumnName("Fax").IsOptional();
            Property(x => x.GoogleMap).HasColumnName("GoogleMap").IsOptional();
            

            

        }
    }
}
