using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RomHeredia.Models
{
    public class BlogComment
    {
        public int BlogCommentId { get; set; }

        public int BlogPostId { get; set; }

        public string Author { get; set; }
        
        [Required]
        public string Body { get; set; }

        public DateTime Posted { get; set; }
    }
}
