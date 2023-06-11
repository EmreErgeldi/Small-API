using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Small_API.Models;
using Small_API.Services.BlogService;
using System.Reflection.Metadata;

namespace Small_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private static IBlogService? _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Blog>>> GetAllBlogs()
        {
            var blogs = await _blogService.GetAllBlogs();
            if (blogs is null)
                return NotFound();

            return Ok(blogs);
        }

        [HttpGet("user/{createdBy}")]
        public async Task<ActionResult<List<Blog>>> GetBlogsByUser(int createdBy)
        {
            var blogs = await _blogService.GetBlogsByUser(createdBy);
            if (blogs is null)
                return NotFound("Blogs not found");

            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id)
        {
            var blog = await _blogService.GetBlog(id);
            if (blog is null)
                return NotFound("Blog with id " + id + " not found");

            return Ok(blog);
        }

        [HttpPost]
        public async Task<ActionResult<List<Blog>>> AddBlog(Blog blog)
        {
            var blogs = await _blogService.AddBlog(blog);
            if (blogs is null)
                return NotFound();

            return Ok(blogs);
        }

        [HttpPut]
        public async Task<ActionResult<List<Blog>>> UpdateBlog(Blog newBlog)
        {
            var blogs = await _blogService.UpdateBlog(newBlog);
            if (blogs is null)
                return NotFound();

            return Ok(blogs);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Blog>> DeleteBlog(int id)
        {
            var blog = await _blogService.DeleteBlog(id);
            if (blog is null)
                return NotFound("Blog with id " + id + " not found");

            return Ok(blog);
        }
    }
}
