using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvcBlog.Models;
using mvcBlog.Services;

namespace mvcBlog.Controllers
{
    // [Authorize]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostsController(IPostService postService, UserManager<ApplicationUser> userManager)
        {
            _postService = postService;
            _userManager = userManager;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetPostsByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID is required");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"User with ID {userId} not found");
            }

            var allPosts = await _postService.GetAllPostsWithUsersAsync();
            var userPosts = allPosts.Where(p => p.UserId == userId).ToList();

            ViewData["Title"] = $"Posts by {user.UserName}";
            return View("UserPosts", userPosts);
        }
    }
}