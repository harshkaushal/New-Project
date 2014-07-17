using Ekomsys.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ekomsys.DataAccess.Classes;
using Ekomsys.Entities;

namespace Ekomsys.Business.Classes
{
    public class PagesBAL:IPagesBAL
    {
        PagesRepository _repository = null;
        public List<usp_GetAllPages_SubPages_Result> GetAllPages_SubPages()
        {
            _repository = new PagesRepository();
            return _repository.GelAllPages_SubPages();
        }

        public string GetPageContent(int pageId)
        {
            _repository = new PagesRepository();
            return _repository.GetSingle(d => d.Page_Id == pageId).Page_Content;
        }
    }
}
