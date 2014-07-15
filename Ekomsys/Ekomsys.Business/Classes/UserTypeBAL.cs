using Ekomsys.DataAccess.Classes;
using Ekomsys.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekomsys.Business.Classes
{
    public class UserTypeBAL
    {
        UserTypeRepository _repository = null;
       public IList<tb_UserType> GetAllUserType()
        {
            _repository = new UserTypeRepository();
            return _repository.GetAllUserType();
        }
    }
}
