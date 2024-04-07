using CodeFirstApproachCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstApproachCrud.Controllers
{
    public class DemoController : Controller
    {
        EmpDataContext objDataContext = new EmpDataContext();
        // GET: Demo  
        public ActionResult EmpDetails()
        {

            return View(objDataContext.employees.ToList());
        }
        [HttpGet]
        public ActionResult create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult create(Employee objEmp)
        {
            objDataContext.employees.Add(objEmp);
            objDataContext.SaveChanges();
            return View();
        }

        public ActionResult Details(string id)
        {
            int empId = Convert.ToInt32(id);
            var emp = objDataContext.employees.Find(empId);
            return View(emp);
        }

        public ActionResult Edit(string id)
        {
            int empId = Convert.ToInt32(id);
            var emp = objDataContext.employees.Find(empId);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(Employee objEmp)
        {
            var data = objDataContext.employees.Find(objEmp.EmpId);
            if (data != null)
            {
                data.Name = objEmp.Name;
                data.Address = objEmp.Address;
                data.Email = objEmp.Email;
                data.MobileNo = objEmp.MobileNo;
            }
            objDataContext.SaveChanges();
            return View();
        }

        public ActionResult Delete(string id)
        {
            int empId = Convert.ToInt32(id);
            var emp = objDataContext.employees.Find(empId);
            return View(emp);
        }
    }
}