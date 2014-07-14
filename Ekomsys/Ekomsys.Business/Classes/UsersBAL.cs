using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ekomsys.Entities;
using Ekomsys.DataAccess.Classes;

namespace Ekomsys.Business.Classes
{
    public class UsersBAL : Ekomsys.Business.Interfaces.IUsersBAL
    {
        UserRepository _repository = null;
         public int? usp_CheckLogin(tb_Users User)
        {
            _repository = new UserRepository();
            return _repository.usp_CheckLogin(User);
        }

        
    }
}
