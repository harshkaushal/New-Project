using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ekomsys.Entities;

namespace Ekomsys.Business.Interfaces
{
    public interface IPagesBAL
    {
        bool AddPages(tb_Page pages);
        List<tb_Page> GetAllPages();
        void UpdatePages(tb_Page pagesModel);
        void DeletePages(int id);
        List<usp_GetAllPages_SubPages_Result> GetAllPages_SubPages();
        string GetPageContent(int pageId);
    }
}
