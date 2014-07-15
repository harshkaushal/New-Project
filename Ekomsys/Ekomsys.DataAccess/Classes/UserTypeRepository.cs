using Ekomsys.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekomsys.DataAccess.Classes
{
    public class UserTypeRepository : RepositoryBase<tb_UserType>
    {
        public List<tb_UserType> GetAllUserType()
        {
            using (DevSamplesEntities _dbEntity = new DevSamplesEntities())
            {
                List<tb_UserType> dbList = _dbEntity.tb_UserType.ToList();
                return dbList;
            }
        }

    }
}
