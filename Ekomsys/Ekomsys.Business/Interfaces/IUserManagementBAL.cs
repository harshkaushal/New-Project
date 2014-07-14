using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ekomsys.Entities;

namespace Ekomsys.Business.Interfaces
{
   public interface IUserManagementBAL
    {
        bool AddUser(tb_Users news);
        List<tb_Users> GetAllUsers();
        bool UpdateUser(tb_Users userModel);
        bool DeleteUser(tb_Users userModel);
    }
}
