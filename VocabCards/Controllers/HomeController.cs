using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VocabCards.Access;
using VocabCards.DataModels.ViewModels;
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
			RandomWordAPI wordGrabber = new RandomWordAPI();
			string word = wordGrabber.GetWord().ToString() ?? "BrokenAPI";
			WordViewModel model = new WordViewModel();
			model.Word = word;
			return View(model);
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
