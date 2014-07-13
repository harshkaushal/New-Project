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

        public void UpdateNews(tb_News newsModel)
        {
            _repository = new NewsRepository();
            tb_News dbNews = _repository.GetSingle(d => d.News_Id == newsModel.News_Id);
            AutoMapper.Mapper.CreateMap<tb_News, Ekomsys.Entities.tb_News>();
            AutoMapper.Mapper.Map(newsModel, dbNews);

            _repository.SaveChanges();

        }

        public void DeleteNews(int id)
        {
            _repository = new NewsRepository();
            tb_News dbNews = _repository.GetSingle(d => d.News_Id == id);
            _repository.Delete(dbNews);
        }
    }
}
