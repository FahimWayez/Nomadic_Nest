using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //no need to initialize required, automatically insert value through logic
        public string role { get; set; }

        public virtual ICollection<Post> posts { get; set; }

        public User()
        {
            posts = new List<Post>();
        }



        //Post entity
        //public virtual List<Post> Posts { get; set; }
        //public User() {
        //    Posts = new List<Post>();
        //}

        //Service entity
        //public virtual List<Service> Services { get; set; }
        //public User()
        //{
        //    Services = new List<Service>();
        //}
    }
}
