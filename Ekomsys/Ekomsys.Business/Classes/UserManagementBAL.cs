using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ekomsys.Entities;
using Ekomsys.DataAccess.Classes;

namespace Ekomsys.Business.Classes
{
    public class UserManagementBAL : Ekomsys.Business.Interfaces.IUserManagementBAL
    {
        UserManagementRepository _repository = null;
        public List<tb_Users> GetAllUsers()
        {
            _repository = new UserManagementRepository();
            return _repository.GetAllUsers();
        }

        public bool AddUser(tb_Users users)
        {
            _repository = new UserManagementRepository();

            return _repository.AddUser(users);
        }

        public bool UpdateUser(tb_Users userModel)
        {
            _repository = new UserManagementRepository();
            return _repository.UpdateUser(userModel);
            
        }

        public bool DeleteUser(tb_Users user)
        {
            _repository = new UserManagementRepository();
            return _repository.DeleteUser(user);
        }
    }
}
