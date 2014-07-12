using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ekomsys.Entities;
using Ekomsys.DataAccess.Classes;

namespace Ekomsys.Business.Classes
{
    public class NewsBAL : Ekomsys.Business.Interfaces.INewsBAL
    {
        NewsRepository _repository = null;
        public List<tb_News> GetAllNews()
        {
            _repository = new NewsRepository();
            return _repository.GetAllNews();
        }

        public bool AddNews(tb_News news)
        {
            _repository = new NewsRepository();
            return _repository.AddNews(news);
        }
    }
}
