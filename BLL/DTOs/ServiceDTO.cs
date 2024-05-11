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
    public class ServiceDTO
    {
        [Key]
        public int service_id { get; set; }

        [Required]
        public string service_description { get; set; }
        [Required]
        public string service_title { get; set; }
        //for transport service
        public string service_location_to { get; set; }
        [Required]
        public string service_location_from { get; set; }
        [Required]
        public float service_value { get; set; }

        public string service_status { get; set; }


        //User Entity
        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
