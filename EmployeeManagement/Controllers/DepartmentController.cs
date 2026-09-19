using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly EmployeeManagementDBEntities db = new EmployeeManagementDBEntities();


        // GET: Department
        public ActionResult Index()
        {
            var departments = db.Departments.ToList();
            return View(departments);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(400);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }
            db.Departments.Add(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(400);
            }

            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Department department = db.Departments.Find(model.DepartmentId);
            if (department == null)
            {
                return HttpNotFound();
            }
            department.DepartmentName = model.DepartmentName;
            department.Description = model.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(400);
            }

            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }


        // POST: Departments/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(
            int id)
        {
            Department department = db.Departments.Find(id);

            if (department == null)
            {
                return HttpNotFound();
            }

            db.Departments.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }

    }
}