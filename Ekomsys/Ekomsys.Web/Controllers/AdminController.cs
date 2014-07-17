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
        private readonly IUserManagementBAL _userBal;
        private readonly IUserTypeBAL _userTypeBal;

        public AdminController(INewsBAL newsBAL, IUserManagementBAL userBal,IUserTypeBAL userTypeBal)
        {
            _newsBal = newsBAL;
            _userBal = userBal;
            _userTypeBal = userTypeBal;
        }

        public ActionResult Index()
        {
            return View();
        }

        [MyAuthorize]
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

        #region "News Management"

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

        #endregion

        #region "User Management"

        public ActionResult UserManagement()
        {
            ViewData["AllUserType"] = new SelectList(_userTypeBal.GetAllUserType(), "UserType_Id", "Name"); ;
            return View();
        }

        public ActionResult User_Read([DataSourceRequest]DataSourceRequest request)
        {
            ViewData["AllUserType"] = new SelectList(_userTypeBal.GetAllUserType(), "UserType_Id", "Name"); ;
            return Json(_userBal.GetAllUsers().ToDataSourceResult(request));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult User_Create([DataSourceRequest] DataSourceRequest request, UserManagementModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                tb_Users modelUser = new tb_Users();
                AutoMapper.Mapper.CreateMap<UserManagementModel, tb_Users>();
                modelUser = AutoMapper.Mapper.Map(model, modelUser);
                modelUser.Created_By = 1;
                modelUser.Created_Date = DateTime.Now;
                modelUser.Modify_By = 1;
                modelUser.Modify_Date = DateTime.Now;
                modelUser.Password = "123456";
                _userBal.AddUser(modelUser);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult User_Update([DataSourceRequest] DataSourceRequest request, UserManagementModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                tb_Users modelUser = new tb_Users();
                AutoMapper.Mapper.CreateMap<UserManagementModel, tb_Users>();
                modelUser = AutoMapper.Mapper.Map(model, modelUser);
                modelUser.Modify_By = 1;
                modelUser.Modify_Date = DateTime.Now;
                _userBal.UpdateUser(modelUser);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult User_Destroy([DataSourceRequest] DataSourceRequest request, UserManagementModel model)
        {
            if (model != null)
            {
                tb_Users modelUser = new tb_Users();
                AutoMapper.Mapper.CreateMap<UserManagementModel, tb_Users>();
                modelUser = AutoMapper.Mapper.Map(model, modelUser);
                _userBal.DeleteUser(modelUser);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        #endregion
    }
}
