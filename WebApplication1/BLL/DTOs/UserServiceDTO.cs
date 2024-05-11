using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserServiceDTO
    {
        //Post entity
        public List<ServiceDTO> services { get; set; }
        public UserServiceDTO()
        {
            services = new List<ServiceDTO>();
        }
    }
}
