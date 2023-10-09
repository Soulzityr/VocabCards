using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VocabCards.Access;
using VocabCards.Models;

namespace VocabCards.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			RandomWordAPIController wordGrabber = new RandomWordAPIController();
			string word = wordGrabber.Get().ToString() ?? "BrokenAPI";
			return View(word);
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
