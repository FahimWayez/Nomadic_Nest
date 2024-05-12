using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IChangePass<CLASS, ID, RET>
    {
        RET ChangePassword(int id, CLASS obj);
        //RET Update(int id, CLASS obj);
        CLASS Get(ID id);
    }
}
