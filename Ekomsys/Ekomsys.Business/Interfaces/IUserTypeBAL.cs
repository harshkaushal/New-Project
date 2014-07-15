using Ekomsys.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekomsys.Business.Interfaces
{
    public interface IUserTypeBAL
    {
        IList<tb_UserType> GetAllUserType();
    }
}
