using Microsoft.AspNetCore.Mvc;

namespace ErpCollege.Controllers
{
	public class TeacherController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
