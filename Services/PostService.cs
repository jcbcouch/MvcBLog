using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvcBlog.Models;
using mvcBlog.Repository;
using Microsoft.EntityFrameworkCore;

namespace mvcBlog.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _postRepository;

        public PostService(IRepository<Post> postRepository)
        {
            _postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _postRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Post>> GetAllPostsWithUsersAsync()
        {
            return await _postRepository.GetAllIncludingAsync(p => p.User);
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _postRepository.GetByIdAsync(id);
        }

        public async Task<Post> GetPostWithUserByIdAsync(int id)
        {
            return await _postRepository.GetByIdIncludingAsync(id, p => p.User);
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
            if (post == null)
                throw new ArgumentNullException(nameof(post));

            await _postRepository.AddAsync(post);
            await _postRepository.SaveAsync();
            return post;
        }

        public async Task UpdatePostAsync(Post post)
        {
            if (post == null)
                throw new ArgumentNullException(nameof(post));

            _postRepository.UpdateAsync(post);
            await _postRepository.SaveAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post != null)
            {
                await _postRepository.DeleteAsync(post);
                await _postRepository.SaveAsync();
            }
        }

        public async Task<bool> PostExistsAsync(int id)
        {
            return await _postRepository.ExistsAsync(id);
        }
    }
}
