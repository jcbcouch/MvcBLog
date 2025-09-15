using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace mvcBlog.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Navigation property for the posts created by this user
        [ValidateNever]
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
