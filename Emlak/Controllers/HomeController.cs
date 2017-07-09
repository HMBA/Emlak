using Emlak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Emlak.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult LogOn()
        {
            return View();
        }
        public ViewResult Index()
        {
            return View();
        }
        
        public ViewResult HomeForSale()
        {
            List<Home> homeList = new List<Home>();
            Home home = new Models.Home ();
            homeList = home.getAllHomes();
            ViewBag.HomeList = homeList;
            return View();
        }
        public ViewResult Kitchen()
        {
            return View();
        }
        public ViewResult Register()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }
        public ActionResult TermOfUse()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult LogOn(Login model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsUserExist(model.EmailId, model.Password))
                {
                    ViewBag.Email = model.EmailId;

                    FormsAuthentication.SetAuthCookie(model.EmailId,false);
                    Response.Redirect("~/Home/Home");
                }
                else
                {
                    ModelState.AddModelError("", "EmailId or Password Incorrect.");
                }
            }
            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Register(Register model)
        {

            if (ModelState.IsValid)
            {
               
                    if (model.Insert())
                    {
                        return RedirectToAction("LogOn", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email Already Exist");
                    }
            }
            else
            {
                ModelState.AddModelError("", "Email or Password is Incorrect");
            }
            return View(model);
        }
    }
}