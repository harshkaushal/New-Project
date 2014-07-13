using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ekomsys.Entities;

namespace Ekomsys.Business.Interfaces
{
    public interface INewsBAL
    {
        bool AddNews(tb_News news);
        List<tb_News> GetAllNews();
        void UpdateNews(tb_News newsModel);
        void DeleteNews(int id);
    }
}
