using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using Ekomsys.Entities;
namespace Ekomsys.DataAccess.Classes
{
    public class UserRepository : RepositoryBase<tb_Users>
    {
        DevSamplesEntities _dbEntity = new DevSamplesEntities();
        public int? usp_CheckLogin(tb_Users User)
        {
            return _dbEntity.usp_CheckLogin(User.User_Name, User.Password).FirstOrDefault(); ;
        }
    }
}
