using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUser<TYPE, ID, RET>
    {
        RET ChangePassword(int id, string exPassword, string newPassword);
    }
}
