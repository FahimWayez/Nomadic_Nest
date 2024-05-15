using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Post
    {
        [Key]
        public int post_id { get; set; }

        [Required]
        public string post_description { get; set; }
        public string post_title { get; set; }
        [Required]
        public string post_location { get; set; }

        public DateTime post_created { get; set; } = DateTime.Now;


        //User Entity
        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Comment> comments { get; set; }

        public Post()
        {
            comments = new List<Comment>();
            
        }

    }
}
