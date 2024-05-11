using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Token
    {
        [Key]
        public int TokenId { get; set; }

        [Required]
        [StringLength(100)]
        public string TokenKey { get; set; }
        [Required]
        public DateTime TokenCreate {  get; set; }        
        public DateTime? TokenDestroy { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
