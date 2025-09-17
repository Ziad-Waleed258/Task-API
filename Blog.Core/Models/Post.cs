using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }  // PK
        [Required(ErrorMessage = "Title Is Required")]
        [StringLength(150, MinimumLength = 4)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Content Is Required")]
        [StringLength(400, MinimumLength = 20)]
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        // Relations
        // UserId
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        // CategoryId
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public ICollection<Comment> Comments { get; set; } = new List<Comment>();


    }
}
