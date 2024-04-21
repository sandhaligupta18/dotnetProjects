using InnerJoin.Models;
using InnerJoin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InnerJoin.Controllers
{
    public class Trainee2Controller : Controller
    {
        public ActionResult GetAllTraineeMergeDetails()
        {
            Trainee1Repo trainee1Repo = new Trainee1Repo();
            ModelState.Clear();
            return View(trainee1Repo.GetAllTraineeMergeData());
        }
        public ActionResult GetAllTrainee1Details()
        {
            Trainee1Repo trainee1Repo = new Trainee1Repo();
            ModelState.Clear();
            return View(trainee1Repo.GetAllTrainee1Data());
        }
        [HttpGet]
        public ActionResult AddTrainee1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTrainee1(Trainee1Model trainee1Model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Trainee1Repo traineeRepo = new Trainee1Repo();
                    if (traineeRepo.AddTrainee1(trainee1Model))
                    {
                        ViewBag.Message = "Employee details added successfully";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
