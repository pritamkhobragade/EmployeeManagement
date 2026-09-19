using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class DashboardController : Controller
    {

        private readonly EmployeeManagementDBEntities db = new EmployeeManagementDBEntities();


        // GET: Dashboard
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("login", "Account");
            }
            return View();
        }

        [HttpGet]
        public JsonResult GetDashboardData()
        {
            int TotalEmployee = db.Employees.Count();
            int TotalDepartments = db.Departments.Count();
            //int activeEmployees = db.Employees.Count(x => x.Status == "Active");
            int activeEmployees = db.Employees.Count(x => x.Status != null && x.Status.Trim().ToLower() == "Active");

            int inactiveEmployees = TotalEmployee - activeEmployees;

            //int inactiveEmployees = db.Employees.Count(x => x.Status == "Inctive");
            decimal totalSalary = db.Employees.Select(x => (decimal?)x.Salary).Sum() ?? 0;

            // Percentage
            double activePercentage = 0;
            double inactivePercentage = 0;
            if (TotalEmployee > 0)
            {
                activePercentage =((double)activeEmployees / TotalEmployee) * 100;
                inactivePercentage = ((double)inactiveEmployees / TotalEmployee) * 100;
            }


            return Json(new
            {
                TotalEmployee = TotalEmployee,

                TotalDepartments = TotalDepartments,

                activeEmployees = activeEmployees,

                inactiveEmployees = inactiveEmployees,

                totalSalary = totalSalary,

                //activePercentage = activePercentage,

                //inactivePercentage = inactivePercentage,

                activePercentage = Math.Round(activePercentage, 1),

                inactivePercentage = Math.Round(inactivePercentage,1)


            }, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(
            bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }

}