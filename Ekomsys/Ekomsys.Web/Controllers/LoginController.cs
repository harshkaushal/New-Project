using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ekomsys.Business.Classes;
using Ekomsys.Entities;
using Ekomsys.Web.Models;

namespace Ekomsys.Web.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        UsersBAL _userClass = new UsersBAL();
        public ActionResult Index()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Index(UserModel User)
        {
            AutoMapper.Mapper.CreateMap<UserModel, tb_Users>();
            tb_Users newUser = new tb_Users();
            newUser = AutoMapper.Mapper.Map(User, newUser);
            if (_userClass.usp_CheckLogin(newUser) == 1)
            {
                FormAuthentication(User);
                return RedirectToAction("News", "Admin");
            }
            ViewBag.Message = "Please enter valid Username & Password";
            return View(); ;
        }


        public ActionResult Forgot_Password()
        {

            ViewBag.Step = "1";
            return View();
        }
        //[HttpPost]
        //public ActionResult Forgot_Password(UserModel User)
        //{
        //    //int? returnValue = _userClass.usp_CheckForgotPasword(User);
        //    //if (returnValue != 0)
        //    //{
        //    //    ViewBag.Step = "2";
        //    //    User.User_Id = Convert.ToInt32(returnValue);
        //    //    return View(User);
        //    //}

        //    //ViewBag.Step = "1";
        //    //ViewBag.Message = "Please fill the correct information";
        //    //return View();
        //}

        //[HttpPost]
        //public ActionResult ChangePassword(UserModel User)
        //{
        //    _userClass.usp_ChangePassword(User);

        //    return RedirectToAction("Index");
        //    // return Json("Success");
        //}
        public ActionResult Logout()
        {
            Session["User"] = User;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        public void FormAuthentication(UserModel User)
        {


            //string userData = JsonConvert.SerializeObject(User);
            //FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
            //1,
            //User.First_Name,
            //DateTime.Now,
            //DateTime.Now.AddMinutes(15),
            //false, //pass here true, if you want to implement remember me functionality
            //userData);

            //string encTicket = FormsAuthentication.Encrypt(authTicket);
            Session["User"] = User;
            FormsAuthentication.SetAuthCookie(User.User_Name, false);
            //HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            //Response.Cookies.Add(faCookie);
        }

    }
}
