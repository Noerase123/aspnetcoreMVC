using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Post
    {
        [Key]
        public int postId {get;set;}
        [Required]
        public string title {get;set;}
        [Required] 
        public string body {get;set;}
    }
}