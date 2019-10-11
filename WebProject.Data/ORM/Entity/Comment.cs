using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Data.ORM.Entity
{
    public class Comment : BaseEntity
    {//Customer Comments
        public string CustomerName { get; set; }
        public string Authority { get; set; }
        public string CompanyName { get; set; }
        public byte[]  ProfilePhotoURL { get; set; }
        public string CommentContent { get; set; }
        public string Email { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

    }
}
