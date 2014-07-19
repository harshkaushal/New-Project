using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ekomsys.Entities;

namespace Ekomsys.DataAccess.Classes
{
    public class PagesRepository : RepositoryBase<tb_Page>
    {
        public bool AddPages(tb_Page pagesModel)
        {
            using (DevSamplesEntities _dbEntity = new DevSamplesEntities())
            {
                try
                {
                    
                    _dbEntity.tb_Page.Add(pagesModel);
                    _dbEntity.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool UpdatePages(tb_Page pagesModel)
        {
            using (DevSamplesEntities _dbEntity = new DevSamplesEntities())
            {
                try
                {
                    Update(pagesModel);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public List<tb_Page> GetAllPages()
        {
            using (DevSamplesEntities _dbEntity = new DevSamplesEntities())
            {
                List<tb_Page> dbList = _dbEntity.tb_Page.OrderByDescending(d => d.Page_Id).ToList();
                return dbList;
            }
        }
        public List<usp_GetAllPages_SubPages_Result> GelAllPages_SubPages()
        {
            using (DevSamplesEntities _dbEntity = new DevSamplesEntities())
            {
                return _dbEntity.usp_GetAllPages_SubPages().ToList();
            }
        }

    }
}
