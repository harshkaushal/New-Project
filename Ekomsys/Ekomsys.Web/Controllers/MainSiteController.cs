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

    }
}
