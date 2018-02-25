using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RomHeredia.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public string Author { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime Posted { get; set; }

        public ICollection<BlogComment> BlogComments { get; set; }
    }
}
