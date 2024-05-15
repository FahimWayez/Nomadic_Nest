using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PostDTO
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
        //[ForeignKey("User")]
        public int UserId { get; set; }

        //public virtual User User { get; set; }
    }
}
