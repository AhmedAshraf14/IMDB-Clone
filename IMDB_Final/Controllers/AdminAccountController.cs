using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMDB_Final;
using IMDB_Final.Services;

namespace IMDB_Final.Models
{
    public class AdminAccountController : Controller
    {
        private AppDbContext db;
        private readonly AdminServices MainInterFace;

        public AdminAccountController()
        {
            MainInterFace = new AdminServices();
            db = new AppDbContext();
        }
        // GET: Admin/AdminAccount/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin UserData)
        {
            var isLoggedIn = MainInterFace.Login(UserData.AdminName, UserData.Password);
            if (isLoggedIn == 1)
            {
                return RedirectToAction("LoggedIn", "AdminAccount");
            }
            if (isLoggedIn == 2)
            {
                return RedirectToAction("Login", "User", new { User = UserData.AdminName });

            }
            else
            {
                ModelState.AddModelError("", "Username or Password is wrong");

            }

            return View();
        }
        public ActionResult LoggedIn()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}