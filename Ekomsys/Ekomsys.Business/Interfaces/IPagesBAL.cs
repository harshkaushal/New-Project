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
        List<usp_GetAllPages_SubPages_Result> GetAllPages_SubPages();
        string GetPageContent(int pageId);
    }
}
