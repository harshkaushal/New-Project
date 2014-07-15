using Ekomsys.Business.Interfaces;
using Ekomsys.Business.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ekomsys.Entities;
using Ekomsys.Web.Models;

namespace Ekomsys.Web.Controllers
{
    public class MainSiteController : Controller
    {
        //
        // GET: /MainSite/

        private readonly IContactBAL _contactBal;
        public MainSiteController(IContactBAL contactBal)
        {
            _contactBal = contactBal;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            AutoMapper.Mapper.CreateMap<usp_getOfficeDetails_Result, ContactModel>();
            var _details = _contactBal.GetContactDetail();
            ContactModel _model = new ContactModel();
            _model = AutoMapper.Mapper.Map(_details, _model);
            return View(_model);
        }

    }
}
