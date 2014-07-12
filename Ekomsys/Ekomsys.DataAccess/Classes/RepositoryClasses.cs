﻿using System;
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

        public bool AddNews(tb_News newsModel)
        {
            using (Edmx.DevSamplesEntities _dbEntity=new Edmx.DevSamplesEntities())
            {
                try
                {
                    Edmx.tb_News news = new Edmx.tb_News();
                   
                    AutoMapper.Mapper.CreateMap<tb_News,Edmx.tb_News>();
                    news = AutoMapper.Mapper.Map(newsModel, news);
                    _dbEntity.tb_News.Add(news);
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
            using (Edmx.DevSamplesEntities _dbEntity=new Edmx.DevSamplesEntities())
            {
                List<Edmx.tb_News> dbList = _dbEntity.tb_News.OrderByDescending(d => d.News_Id).ToList();
                AutoMapper.Mapper.CreateMap<Edmx.tb_News, tb_News>();
                List<tb_News> newsModel = new List<tb_News>();
                newsModel = AutoMapper.Mapper.Map(dbList, newsModel);
                return newsModel;
            }
        }

    }
   
}