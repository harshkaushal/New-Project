using Ekomsys.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekomsys.DataAccess.Classes
{
    public class ContactRepository : RepositoryBase<usp_getOfficeDetails_Result>
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
