using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ekomsys.Business;
using Ekomsys.Business.Interfaces;
using Ekomsys.Business.Classes;
using Ekomsys.Entities;
using Kendo.Mvc.UI;
using Ekomsys.Web.Models;
using Kendo.Mvc.Extensions;
using Ekomsys.DataAccess.Interfaces;

namespace Ekomsys.Web.Controllers
{

    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        private readonly INewsBAL _newsBal;

        public AdminController(INewsBAL newsBAL)
        {
            _newsBal = newsBAL;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult News()
        {
            var result = _newsBal.GetAllNews();
            AutoMapper.Mapper.CreateMap<tb_News, NewsModel>();
            List<NewsModel> newsModel = new List<NewsModel>();
            newsModel = AutoMapper.Mapper.Map(result, newsModel);
            return View(newsModel);
        }

        [HttpGet]
        public JsonResult NewsList()
        {
            var lst = _newsBal.GetAllNews().ToList();
            return this.Json(lst, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult News(tb_News NewsModel, FormCollection form)
        {
            NewsModel.Created_By = 1;
            NewsModel.Modify_By = 1;
            NewsModel.Created_Date = DateTime.UtcNow;
            NewsModel.Modify_Date = DateTime.UtcNow;
            NewsModel.Posted_Date = DateTime.UtcNow;

            //NewsModel.Title = Request.Form["title"];
            NewsModel.Is_Active = true;
            _newsBal.AddNews(NewsModel);

            return View(_newsBal.GetAllNews());
        }

        public JsonResult Update(tb_News NewsModel)
        {
            NewsModel.Modify_Date = DateTime.UtcNow;
            _newsBal.UpdateNews(NewsModel);
            var lst = _newsBal.GetAllNews().ToList();
            return this.Json(lst, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteNews(tb_News NewsModel)
        {

            _newsBal.DeleteNews(NewsModel.News_Id);
            var lst = _newsBal.GetAllNews().ToList();
            return this.Json(lst, JsonRequestBehavior.AllowGet);
        }

        public ActionResult News_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(_newsBal.GetAllNews().ToDataSourceResult(request));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult News_Create([DataSourceRequest] DataSourceRequest request, NewsModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                tb_News modelNew = new tb_News();
                AutoMapper.Mapper.CreateMap<NewsModel, tb_News>();
                modelNew = AutoMapper.Mapper.Map(model, modelNew);
                modelNew.Posted_Date = DateTime.Now;
                modelNew.Created_By = 1;
                modelNew.Created_Date = DateTime.Now;
                modelNew.Modify_By = 1;
                modelNew.Modify_Date = DateTime.Now;
                _newsBal.AddNews(modelNew);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult News_Update([DataSourceRequest] DataSourceRequest request, NewsModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                tb_News modelNew = new tb_News();
                AutoMapper.Mapper.CreateMap<NewsModel, tb_News>();
                modelNew = AutoMapper.Mapper.Map(model, modelNew);
                modelNew.Modify_By = 1;
                modelNew.Modify_Date = DateTime.Now;
                _newsBal.UpdateNews(modelNew);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult News_Destroy([DataSourceRequest] DataSourceRequest request, NewsModel model)
        {
            if (model != null)
            {
                tb_News modelNew = new tb_News();
                AutoMapper.Mapper.CreateMap<NewsModel, tb_News>();
                modelNew = AutoMapper.Mapper.Map(model, modelNew);
                _newsBal.UpdateNews(modelNew);
                //int empId = model.Emp_Id;
                _newsBal.DeleteNews(modelNew.News_Id);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}
