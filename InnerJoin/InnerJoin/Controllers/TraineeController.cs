using InnerJoin.Models;
using InnerJoin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InnerJoin.Controllers
{
    public class TraineeController : Controller
    {

        public ActionResult GetAllTraineeDetails()
        {
            TraineeRepo traineeRepo = new TraineeRepo();
            ModelState.Clear();


            return View(traineeRepo.GetAllTraineeData());

        }

        [HttpGet]
         public ActionResult AddTrainee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTrainee(TraineeModel traineeModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TraineeRepo traineeRepo = new TraineeRepo();
                    if(traineeRepo.AddTrainee(traineeModel))
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
