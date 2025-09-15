using System.ComponentModel.DataAnnotations;

namespace mvcBlog.Models.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        
        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
    }
}
