//using Emlak.DAL;
//using Emlak.Models;
//using Emlak.ModelView;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace Emlak.Controllers
//{
//    public class UserController : Controller
//    {
//        //
//        // GET: /User/
//        public ActionResult Index()
//        {
//            UserModelView userModel = new UserModelView();
//            DAL.DAL db = new DAL.DAL();
//            userModel.ListOfUsers = db.users.ToList();

//            return View(userModel);
//        }
//        [HttpGet]
//        public ActionResult Register()
//        {
//            return View();
//        }
//        [HttpPost]
//        public ActionResult Register(User user)
//        {
//            return View();
//        }
//        [HttpGet]
//        public ActionResult Login()
//        {
//            return View();
//        }
//        [HttpPost]
//        public ActionResult Login(User user)
//        {
//            return View();
//        }
//    }
//}