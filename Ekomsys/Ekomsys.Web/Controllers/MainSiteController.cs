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
        private readonly IPagesBAL _pageBal;
        public MainSiteController(IContactBAL contactBal, IPagesBAL pageBal)
        {
            _contactBal = contactBal;
            _pageBal = pageBal;
        }

        public ActionResult Index()
        {
            return View();
        }

        #region "Home Section"

        public ActionResult Home()
        {
            List<PagesModel> pageModel = new List<PagesModel>();
            var result = _pageBal.GetAllPages_SubPages();
            AutoMapper.Mapper.CreateMap<usp_GetAllPages_SubPages_Result, PagesModel>();
            pageModel = AutoMapper.Mapper.Map(result, pageModel);
            return View(pageModel);
        }

        [HttpGet]
        public ActionResult LoadPageMenu()
        {
            List<PagesModel> pageModel = new List<PagesModel>();
            var result = _pageBal.GetAllPages_SubPages();
            AutoMapper.Mapper.CreateMap<usp_GetAllPages_SubPages_Result, PagesModel>();
            pageModel = AutoMapper.Mapper.Map(result, pageModel);
            return PartialView("_PageMenu", pageModel);
        }

        [HttpPost]
        public string LoadPageContent(int pageId)
        {
            return _pageBal.GetPageContent(pageId);
        }

        #endregion

        #region "Contact Section"

        public ActionResult Contact()
        {
            AutoMapper.Mapper.CreateMap<usp_getOfficeDetails_Result, OfficeDetailModel>();
            var _details = _contactBal.GetContactDetail();
            OfficeDetailModel _officeModel = new OfficeDetailModel();
            _officeModel = AutoMapper.Mapper.Map(_details, _officeModel);
            ContactModel contactModel = new ContactModel();
            contactModel.OfficeDetail = _officeModel;
            return View(contactModel);
        }

        [HttpPost]
        public ActionResult Contact(ContactModel contactModel)
        {
            tb_Contact dbContact = new tb_Contact();
            contactModel.Modify_By = 1;
            contactModel.Modify_Date = DateTime.UtcNow;
            contactModel.Created_By = 1;
            contactModel.Created_Date = DateTime.UtcNow;
            contactModel.Is_Active = true;

            AutoMapper.Mapper.CreateMap<ContactModel, tb_Contact>();
            dbContact = AutoMapper.Mapper.Map(contactModel, dbContact);
            _contactBal.AddContact(dbContact);
            return View();
        }

        #endregion

    }
}
