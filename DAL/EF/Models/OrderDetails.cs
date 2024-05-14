using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsId { get; set; }

        //User Entity
        [ForeignKey("Order")]
        public int order_Id { get; set; }

        public virtual Order Order { get; set; }

        //User Entity
        [ForeignKey("Service")]
        public int service_id { get; set; }

        public virtual Service Service { get; set; }
    }
}
