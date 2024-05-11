using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class User
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
        public string user_phone_number { get; set; }
        [Required]
        public string user_gender { get; set; }
        [Required]
        public string user_city { get; set; }
        [Required]
        public string user_state_name { get; set; }
        [Required]
        public string user_country { get; set; }
        public string role { get; set; }


        public virtual List<Post> Posts { get; set; }
        public User()
        {
            Posts = new List<Post>();
        }

        //Service entity
        //public virtual List<Service> Services { get; set; }
        //public User()
        //{
        //    Services = new List<Service>();
        //}
    }
}
