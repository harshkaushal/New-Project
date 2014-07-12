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

        [HttpPost]
        public ActionResult News(tb_News NewsModel)
        {
            NewsModel.Created_By = 1;
            NewsModel.Modify_By = 1;


            return View();
        }
    }
}
