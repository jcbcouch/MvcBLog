using mvcBlog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mvcBlog.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<IEnumerable<Post>> GetAllPostsWithUsersAsync();
        Task<Post> GetPostByIdAsync(int id);
        Task<Post> GetPostWithUserByIdAsync(int id);
        Task<Post> CreatePostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(int id);
        Task<bool> PostExistsAsync(int id);
    }
}
