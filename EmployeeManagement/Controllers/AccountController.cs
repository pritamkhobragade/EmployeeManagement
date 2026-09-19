using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class AccountController : Controller
    {


        private readonly EmployeeManagementDBEntities db = new EmployeeManagementDBEntities();

        // GET: Account
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(string email, string password)
        {

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) )
            {
                ViewBag.Error = "Please Enter Email And Password.";
                return View();
            }

            var user = db.Users.FirstOrDefault(x => x.Email == email && x.PasswordHash == password
                                            && x.IsActive == true);
            
            if(user== null )
            {
                ViewBag.Error = "Invalid Email & Password.";
                return View();
            }

            Session["UserId"] = user.UserId;
            Session["UserName"] = user.Name;
            Session["RoleId"] = user.RoleId;
            return RedirectToAction("Index", "Dashboard");

        }



        public ActionResult logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login");
        }


        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //}




    }
}