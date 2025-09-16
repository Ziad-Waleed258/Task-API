using Blog.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DTos
{
    public class PostDTo
    {
        public int PostId { get; set; }  // PK
        [Required(ErrorMessage = "Title Is Required")]
        [StringLength(150, MinimumLength = 4)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Content Is Required")]
        [StringLength(400, MinimumLength = 20)]
        public string Content { get; set; }

        // Relations
        // UserId
        public int UserId { get; set; }
        // CategoryId
        public int CategoryId { get; set; }



    }
}
