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
    public class CommentDTO
    {
        [Key]
        public int comment_Id { get; set; }

        [Required]
        public string comment { get; set; }

        public DateTime comment_created { get; set; } = DateTime.Now;

        //post Entity
        //[ForeignKey("Post")]
        public int PostId { get; set; }

        //public virtual Post Post { get; set; }

    }
}
