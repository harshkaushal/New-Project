using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ekomsys.DataAccess.Classes;
using Ekomsys.Entities;

namespace Ekomsys.Business.Classes
{
    public class PagesBAL : Ekomsys.Business.Interfaces.IPagesBAL
    {
        PagesRepository _repository = null;
        public List<tb_Page> GetAllPages()
        {
            _repository = new PagesRepository();
            return _repository.GetAllPages();
        }

        public bool AddPages(tb_Page pages)
        {
            _repository = new PagesRepository();

            return _repository.AddPages(pages);
        }

        public void UpdatePages(tb_Page pagesModel)
        {
            _repository = new PagesRepository();
            _repository.UpdatePages(pagesModel);

        }

        public void DeletePages(int id)
        {
            _repository = new PagesRepository();
            tb_Page dbPages= _repository.GetSingle(d => d.Page_Id == id);
            _repository.Delete(dbPages);
        }
    }
}
