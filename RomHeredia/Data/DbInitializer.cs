using RomHeredia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomHeredia.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BlogContext context)
        {
            context.Database.EnsureCreated();

            if (context.BlogPosts.Any())
            {
                return;
            }

            var blogPosts = new BlogPost[]
            {
                new BlogPost{Title="Blog Post One", Author="Rom Heredia", Body="Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Posted=DateTime.Parse("2018-01-01")},
                new BlogPost{Title="Blog Post Two", Author="Rom Heredia", Body="Suspendisse sit amet ultrices arcu. In et dolor nec nisi aliquam porta non vel nisi.", Posted=DateTime.Parse("2018-01-02")},
                new BlogPost{Title="Blog Post Three", Author="Rom Heredia", Body="Nam sollicitudin nunc non eros posuere feugiat. Cras urna lectus, pulvinar nec nibh sit amet, auctor porttitor tellus.", Posted=DateTime.Parse("2018-01-03")},
                new BlogPost{Title="Blog Post Four", Author="Rom Heredia", Body="Aliquam eu tellus at mauris rhoncus lobortis vel quis elit. Etiam ac luctus lacus.", Posted=DateTime.Parse("2018-01-04")},
                new BlogPost{Title="Blog Post Five", Author="Rom Heredia", Body="Nulla quis ultricies nisi, non malesuada metus. Nulla tincidunt condimentum tristique. Quisque hendrerit dolor at tincidunt lacinia.", Posted=DateTime.Parse("2018-01-05")},
            };

            foreach (BlogPost p in blogPosts)
            {
                context.BlogPosts.Add(p);
            }
            context.SaveChanges();


            var blogComments = new BlogComment[]
            {
                new BlogComment{BlogPostId=1, Author="Rom Heredia", Body="Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Posted=DateTime.Parse("2018-01-01")},
                new BlogComment{BlogPostId=1, Author="Rom Heredia", Body="Suspendisse sit amet ultrices arcu. In et dolor nec nisi aliquam porta non vel nisi.", Posted=DateTime.Parse("2018-01-02")},
                new BlogComment{BlogPostId=2, Author="Rom Heredia", Body="Nam sollicitudin nunc non eros posuere feugiat. Cras urna lectus, pulvinar nec nibh sit amet, auctor porttitor tellus.", Posted=DateTime.Parse("2018-01-03")},
                new BlogComment{BlogPostId=3, Author="Rom Heredia", Body="Aliquam eu tellus at mauris rhoncus lobortis vel quis elit. Etiam ac luctus lacus.", Posted=DateTime.Parse("2018-01-04")},
                new BlogComment{BlogPostId=4, Author="Rom Heredia", Body="Nulla quis ultricies nisi, non malesuada metus. Nulla tincidunt condimentum tristique. Quisque hendrerit dolor at tincidunt lacinia.", Posted=DateTime.Parse("2018-01-05")},
            };

            foreach (BlogComment c in blogComments)
            {
                context.BlogComments.Add(c);
            }
            context.SaveChanges();
        }
    }
}
