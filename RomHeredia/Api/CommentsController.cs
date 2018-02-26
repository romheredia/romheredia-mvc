using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RomHeredia.Data;
using RomHeredia.Models;

namespace RomHeredia.Api
{
    [Produces("application/json")]
    [Route("api/posts/{postId}/Comments")]
    public class CommentsController : Controller
    {
        private readonly BlogContext _context;

        public CommentsController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/posts/5/Comments
        [HttpGet]
        public IQueryable<BlogComment> GetBlogComments(int postId)
        {
            return _context.BlogComments.Where(x => x.BlogPostId == postId);
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogComment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blogComment = await _context.BlogComments.SingleOrDefaultAsync(m => m.BlogCommentId == id);

            if (blogComment == null)
            {
                return NotFound();
            }

            return Ok(blogComment);
        }

        // PUT: api/Comments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogComment([FromRoute] int id, [FromBody] BlogComment blogComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blogComment.BlogCommentId)
            {
                return BadRequest();
            }

            _context.Entry(blogComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogCommentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/posts/5/Comments
        [HttpPost]
        public async Task<IActionResult> PostBlogComment(int postId, [FromBody] BlogComment blogComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = _context.BlogPosts.FirstOrDefault(x => x.Id == postId);
            if (post == null)
            {
                return null;
            }

            blogComment.BlogPostId = postId;
            blogComment.Author = (User.Identity.Name == null) ? "Anonymous" : User.Identity.Name;
            blogComment.Posted = DateTime.Now;

            _context.BlogComments.Add(blogComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlogComment", new { id = blogComment.BlogCommentId }, blogComment);
        }

        // DELETE: api/posts/5/Comments
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogComment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blogComment = await _context.BlogComments.SingleOrDefaultAsync(m => m.BlogCommentId == id);
            if (blogComment == null)
            {
                return NotFound();
            }

            _context.BlogComments.Remove(blogComment);
            await _context.SaveChangesAsync();

            return Ok(blogComment);
        }

        private bool BlogCommentExists(int id)
        {
            return _context.BlogComments.Any(e => e.BlogCommentId == id);
        }
    }
}