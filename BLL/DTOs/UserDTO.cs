using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserDTO
    {
        [Key]
        public int user_id { get; set; }

        [Required]
        public string user_name { get; set; }
        [Required]
        [EmailAddress]
        public string user_email { get; set; }
        [Required]
        public string user_password { get; set; }
        //no need to initialize required
        public string user_phone_number { get; set; }
        [Required]
        public string user_gender { get; set; }
        [Required]
        public string user_city { get; set; }
        [Required]
        public string user_state_name { get; set; }
        [Required]
        public string user_country { get; set; }
        //no need to initialize required automatically insert value through logic
        public string role { get; set; }

        //Post entity
        //public virtual List<PostDTO> Posts { get; set; }
        //public UserDTO()
        //{
        //    Posts = new List<PostDTO>();
        //}
    }
}
