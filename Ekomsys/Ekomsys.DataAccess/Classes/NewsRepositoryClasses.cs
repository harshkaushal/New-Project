using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using Ekomsys.Entities;



//using USAGreenCard.Entities.Poco;

namespace Ekomsys.DataAccess.Classes
{

    public class NewsRepository : RepositoryBase<tb_News>
    {

        //USAGreenCard.DataAccess.Edmx.usagreencardEntities db = new Edmx.usagreencardEntities();
        //public List<CountryLanguageVariant> GetAllCountries(Int32 LanguageId)
        //{
        //    var listCountry = (from c in db.Countries
        //                       join cl in db.CountryLanguageVariants on c.CountryId equals cl.CountryId
        //                       where cl.LanguageId == LanguageId
        //                       select cl).OrderBy(o => o.CountryLanguageVariant1).ToList();
        //    return listCountry;
        //}
        //public NewsRepository(RepositoryContext dataContext) 
        //    : base(dataContext)
        //{
        //}
        public bool AddNews(tb_News newsModel)
        {
            using (DevSamplesEntities _dbEntity = new DevSamplesEntities())
            {
                try
                {
                    //Ekomsys.Entities.tb_News news = new Ekomsys.Entities.tb_News();
                    
                    //AutoMapper.Mapper.CreateMap<tb_News, Ekomsys.Entities.tb_News>();
                    //news = AutoMapper.Mapper.Map(newsModel, news);
                    _dbEntity.tb_News.Add(newsModel);
                    _dbEntity.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool UpdateNews(tb_News newsModel)
        {
            using (DevSamplesEntities _dbEntity = new DevSamplesEntities())
            {
                try
                {
                    Update(newsModel);

                    //tb_News dbNews =  _dbEntity.tb_News.SingleOrDefault(d => d.News_Id == newsModel.News_Id);
                    //AutoMapper.Mapper.CreateMap<tb_News, Ekomsys.Entities.tb_News>();
                    //AutoMapper.Mapper.Map(newsModel, dbNews);

                   
                    
                    //_dbEntity.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public List<tb_News> GetAllNews()
        {
            using (DevSamplesEntities _dbEntity = new DevSamplesEntities())
            {
                List<tb_News> dbList = _dbEntity.tb_News.OrderByDescending(d => d.News_Id).ToList();
                //AutoMapper.Mapper.CreateMap<Ekomsys.Entities.tb_News, tb_News>();
                //List<tb_News> newsModel = new List<tb_News>();
                //newsModel = AutoMapper.Mapper.Map(dbList, newsModel);
               
                return dbList;
            }
        }

    }
   
}