using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public ActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Signin()
        {
            return View();
        }

        DBGR93Entities db = new DBGR93Entities();

        [HttpPost]
        public ActionResult Register(REGISTRATION user)
        {

            try
            {
                db.REGISTRATIONs.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            catch
            {
                return View();
            }

        }

        [HttpPost]

        public ActionResult Signin(REGISTRATION user)
        {

            bool result = IsValid(user.EMAIL, user.PASSWORD);

            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.message = "Login Failed";

            }


            return View(user);
        }


        private bool IsValid(string email, string password)
        {

            bool isValid = false;

            var user = db.REGISTRATIONs.FirstOrDefault(o => o.EMAIL == email);

            if (user != null)
            {

                if (user.PASSWORD == password)
                {
                    isValid = true;
                }

            }

            return isValid;

        }



    }
}