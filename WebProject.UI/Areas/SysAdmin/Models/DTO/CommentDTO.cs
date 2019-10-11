using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.UI.Areas.SysAdmin.Models.DTO
{
    public class CommentDTO
    {
        public string CustomerName { get; set; }
        public string Authority { get; set; }
        public string CompanyName { get; set; }
        public byte[] ProfilePhotoURL { get; set; }
        public string CommentContent { get; set; }
        public string Email { get; set; }

        public int UserID { get; set; }
        public int ID { get; set; }
    }
}