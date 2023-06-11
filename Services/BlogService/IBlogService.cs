using Small_API.Models;

namespace Small_API.Services.BlogService
{
    public interface IBlogService
    {
        Task<List<Blog>> GetAllBlogs();

        Task<Blog> GetBlog(int id);

        Task<List<Blog>> GetBlogsByUser(int createdBy);

        Task<Blog> AddBlog(Blog blog);

        Task<Blog> UpdateBlog(Blog newBlog);

        Task<Blog> DeleteBlog(int id);
    }
}
