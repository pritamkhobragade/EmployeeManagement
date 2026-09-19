using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly EmployeeManagementDBEntities db = new EmployeeManagementDBEntities();
        // GET: Employee
        //public ActionResult Index(string search)
        //{
        //    var employee = db.Employees.ToList();

        //    return Content("Employee Count ="+employee.Count);
        //}

        
        public ActionResult Index(string search)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("login", "Account");
            }

            var employee = db.Employees.Include("Department").AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                employee = employee.Where(x => x.Name.Contains(search) ||
                    x.Email.Contains(search) ||
                    x.Position.Contains(search) ||
                    x.Mobile.Contains(search));
            }
            ViewBag.Search = search;
            return View(employee.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(400);

            Employee employee = db.Employees.Include("Department").SingleOrDefault(x => x.Emp_ID == id);

            if (employee == null)
                return HttpNotFound();
            
            return View(employee);
        }


        public ActionResult Create()
        {
            LoadDepartment();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                LoadDepartment(employee.DepartmentId);
                return View(employee);
            }
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void LoadDepartment(int? selectedId = null)
        {
            ViewBag.DepartmentId = new SelectList(db.Departments.ToList(),
                "DepartmentId", "DepartmentName", selectedId);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(400);

            var employee = db.Employees.Find(id);
            if (employee == null)
                return HttpNotFound();

            LoadDepartment(employee.DepartmentId);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee model)
        {
            if (!ModelState.IsValid)
            {
                LoadDepartment(model.DepartmentId);
                return View(model);
            }
            Employee employee = db.Employees.Find(model.Emp_ID);
            if (employee == null)
                return HttpNotFound();

            employee.Name=model.Name;
            employee.Email= model.Email;
            employee.Mobile = model.Mobile;
            employee.Gender = model.Gender;
            employee.Age = model.Age;
            employee.Position = model.Name;
            employee.DepartmentId = model.DepartmentId;
            employee.Salary = model.Salary;
            employee.JoiningDate = model.JoiningDate;
            employee.Status = model.Status;

            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(400);

            Employee employee = db.Employees.Include("Department").SingleOrDefault(x=>x.Emp_ID==id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfired(int id)
        {
            Employee employee = db.Employees.Find(id);
            if(employee == null)
            {
                return HttpNotFound();
            }

            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }









    }
}