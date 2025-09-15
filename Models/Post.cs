using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace mvcBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        
        [Required]
        public string Body { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Foreign key for the user who created the post
        [Required]
        public string UserId { get; set; }
        
        // Navigation property for the user
        [ForeignKey("UserId")]
        [ValidateNever]
        public virtual ApplicationUser User { get; set; }
    }
}
