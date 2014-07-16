using Ekomsys.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekomsys.DataAccess.Classes
{
    public class ContactRepository : RepositoryBase<tb_Contact>
    {

        public usp_getOfficeDetails_Result GetOfficeDetails()
        {
            using (DevSamplesEntities _dbEntity = new DevSamplesEntities())
            {
                return _dbEntity.usp_getOfficeDetails().FirstOrDefault(); ;
            }

        }

    }
}
