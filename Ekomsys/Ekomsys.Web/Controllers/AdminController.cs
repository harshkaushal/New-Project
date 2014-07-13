using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ekomsys.Business;
using Ekomsys.Business.Interfaces;
using Ekomsys.Business.Classes;
using Ekomsys.Entities;

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
            return View(_newsBal.GetAllNews());
        }

        [HttpGet]
        public JsonResult NewsList()
        {
            var lst = _newsBal.GetAllNews().ToList();
            return this.Json(lst,JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult News(tb_News NewsModel,FormCollection form)
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
    }
}
