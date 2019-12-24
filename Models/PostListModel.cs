using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PostListModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Content { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string State { get; set; }
    }
}
