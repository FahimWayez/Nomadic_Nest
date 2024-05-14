using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserPostDTO : UserDTO
    {
        //Post entity
        public List<PostDTO> posts { get; set; }
        public UserPostDTO()
        {
            posts = new List<PostDTO>();
        }

    }
}
