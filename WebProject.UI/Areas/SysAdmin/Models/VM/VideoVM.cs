using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProject.Data.ORM.Entity;

namespace WebProject.UI.Areas.SysAdmin.Models.VM
{
    public class VideoVM
    {
        public VideoVM()
        {
            Video = new Video();
            Videos = new List<Video>();
            Categories = new List<VideoCategory>();
        }
        public Video Video { get; set; }
        public List<VideoCategory> Categories { get; set; }
        public string CategoryName { get; set; }
        public string UserName { get; set; }
        public List<Video> Videos { get; set; }
    }
}