using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ekomsys.Entities;

namespace Ekomsys.DataAccess.Classes
{
    public class UserManagementRepository : RepositoryBase<tb_Users>
    {
        public List<tb_Users> GetAllUsers()
        {
            using (DevSamplesEntities _dbEntity = new DevSamplesEntities())
            {
                List<tb_Users> dbList = _dbEntity.tb_Users.OrderByDescending(d => d.User_Id).ToList();
                return dbList;
            }
        }

        public bool AddUser(tb_Users userModel)
        {
            using (DevSamplesEntities _dbEntity = new DevSamplesEntities())
            {
                try
                {
                    _dbEntity.tb_Users.Add(userModel);
                    _dbEntity.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool UpdateUser(tb_Users userModel)
        {
            using (DevSamplesEntities _dbEntity = new DevSamplesEntities())
            {
                try
                {
                    Update(userModel);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public bool DeleteUser(tb_Users userModel)
        {
            using (DevSamplesEntities _dbEntity = new DevSamplesEntities())
            {
                try
                {
                    Delete(userModel);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
