using Small_API.Models;

namespace Small_API.Services.BlogService
{
    public class BlogService : IBlogService
    {
        private readonly DataContext _context;

        public BlogService(DataContext context)
        {
            _context = context;
        }


        public async Task<Blog> AddBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();

            return blog;
        }

        public async Task<Blog?> DeleteBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog is null)
                return null;

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();

            return blog;
        }

        public async Task<List<Blog>> GetAllBlogs()
        {
            var blogs = await _context.Blogs.ToListAsync();
            return blogs;
        }

        public async Task<Blog?> GetBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog is null)
                return null;
            return blog;
        }

        public async Task<List<Blog>> GetBlogsByUser(int createdBy)
        {
            var blogs = await _context.Blogs.Where((x)=> x.CreatedBy == createdBy).ToListAsync();

            if(blogs.Count == 0)
            {
                return new List<Blog>();
            }

            return blogs;
        }

        public async Task<Blog?> UpdateBlog(Blog newBlog)
        {
            var blog = await _context.Blogs.FindAsync(newBlog.Id);
            if (blog is null)
                return null;

            blog.Title = newBlog.Title;
            blog.Description = newBlog.Description;
            blog.EnteranceText = newBlog.EnteranceText;
            blog.MainImage = newBlog.MainImage;
            blog.ExtraImages = newBlog.ExtraImages;
            blog.SubTitles = newBlog.SubTitles;
            blog.Paragraphs = newBlog.Paragraphs;
            blog.CreatedBy = newBlog.CreatedBy;
            blog.CreatedAt = newBlog.CreatedAt;
            blog.ApproxReadTime = newBlog.ApproxReadTime;
            blog.Tags = newBlog.Tags;

            await _context.SaveChangesAsync();

            return newBlog;
        }
    }
}
