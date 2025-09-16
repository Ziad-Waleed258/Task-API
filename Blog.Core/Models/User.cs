using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Models
{
    public class User
    {
        //public Guid Id { get; set; }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="UserName Is Required")]
        [StringLength(50,MinimumLength =3)]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Email Is Required")]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password Is Required")]
        //[RegularExpression("")]
        [DataType(DataType.Password)]
        public string Password { get; set; } // hashed password

        // Relations
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
