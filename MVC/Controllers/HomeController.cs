using D4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace D4.Controllers
{
    public class HomeController : Controller
    {
        EmployeeModel db = new EmployeeModel();
        [HttpGet]
        public ActionResult Index()
        {
            var emps = db.Employees.ToList();
            return View(emps);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var depts = db.Departments.ToList();
            ViewBag.depts = new SelectList(depts, "DeptID", "DeptName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var depts = db.Departments.ToList();
                ViewBag.depts = new SelectList(depts, "DeptID", "DeptName");
                return View();
            }
            
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var emp = db.Employees.Find(id);
            var depts = db.Departments.ToList();
            ViewBag.depts = new SelectList(depts, "DeptID", "DeptName", emp.DeptID);
            return View(emp); 
        }

        [HttpPost]
        public ActionResult Edit(Employee newEmp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newEmp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var depts = db.Departments.ToList();
                ViewBag.depts = new SelectList(depts, "DeptID", "DeptName");
                return View();
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
           var e = db.Employees.Find(id);
            db.Employees.Remove(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EmailExist(string Email)
        {
            var result = db.Employees.Any(ww => ww.Email .ToLower().Trim()== Email.ToLower().Trim());
            return Json(!result,JsonRequestBehavior.AllowGet);
        }
    }
}