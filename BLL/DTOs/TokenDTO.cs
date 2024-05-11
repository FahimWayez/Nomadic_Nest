using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TokenDTO
    {    
        public string TokenKey { get; set; }     
        public DateTime TokenCreate { get; set; }
        public DateTime? TokenDestroy { get; set; }
        public string UserId { get; set; }
    }
}
