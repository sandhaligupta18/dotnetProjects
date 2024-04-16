using BussinessAccessLayer.Abstract;
using CrudDotNet.Models;
using DataAccessLayer.ApplicationDB_Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;

namespace CrudDotNet.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDB_Context _appDbContext;
		private readonly IAccountServices _accountServices;
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger, AppDB_Context appDB_Context, IAccountServices accountServices)
		{
			_appDbContext = appDB_Context;
			_accountServices = accountServices;
			_logger = logger;
		}

		public IActionResult AddDepartment()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddDepartment(Department department)
		{
			try
			{
				_logger.LogInformation("Add Department in progress....");
				if (ModelState.IsValid)
				{
					var result = await _accountServices.AddDepartment(department);
					if (result)
					{
						_logger.LogInformation("New Department Added" + department.DepartmentName);
						return RedirectToAction("AddDepartment");
					}
					else
					{
						ViewBag.message = department.DepartmentName + "Already exist ";
						return View();
					}
				}
				else
				{
					ViewBag.message = "Please enter department name";
				}
				return View();
			}
			catch (Exception ex)
			{
				_logger.LogError("Something went wrong" + ex);
				throw;
			}
		}
		public async Task<IActionResult> GetAllUsers()
		{
			var data = await _accountServices.GetDepartments();

			return View(data);
		}


		[HttpGet]
		public IActionResult UpdateDepartment()
		{
			return View();
		}
		[HttpPost]
        public async Task<IActionResult> UpdateDepartment(Department department)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var result = await _accountServices.UpdateDepartment(department);
                    return RedirectToAction("GetAllUsers");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong" + ex);
                throw;
            }
        }
        [HttpGet]
		public async Task<IActionResult> DeleteUser(int id)
		{
			if (ModelState.IsValid)
			{
                var result = await _accountServices.DeleteUser(id);
				return RedirectToAction("GetAllUsers");
            }
			else
			{
				return View();
			}

		}

		
	
	
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
