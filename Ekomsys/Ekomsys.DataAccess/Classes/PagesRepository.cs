using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ekomsys.Entities;

namespace Ekomsys.DataAccess.Classes
{
    public class PagesRepository:RepositoryBase<tb_Page>
    {
        public List<usp_GetAllPages_SubPages_Result> GelAllPages_SubPages()
        {
            using (DevSamplesEntities _dbEntity = new DevSamplesEntities())
            {
                return _dbEntity.usp_GetAllPages_SubPages().ToList();
            }
        }
    }
}
