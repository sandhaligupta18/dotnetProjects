using BusinessAccessLayer.Abstract;
using CruduUsingtheUsermanager.Models;
using DataAccessLayer.ApplicationDB_Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer;
using System.Diagnostics;

namespace CruduUsingtheUsermanager.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDB_Context _appDbContext;
		private readonly IAccountServices _accountServices;
		private readonly UserManager<RegisterUsers> _userManager;
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger, AppDB_Context appDB_Context, IAccountServices accountServices, UserManager<RegisterUsers> userManager)
		{
			_appDbContext = appDB_Context;
			_userManager = userManager;
			_accountServices = accountServices;
			_logger = logger;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllRegisterUsers()
		{

			var data = await _accountServices.GetAllUsers();

			return View(data);

		}
		public IActionResult CreateUser()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateUser(RegisterUsers user)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var result = await _accountServices.CreateUser(user);
					if (result)
					{
						return RedirectToAction("GetAllRegisterUsers");

					}
				}
				return View();
			}
			catch
			{
				throw;
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
