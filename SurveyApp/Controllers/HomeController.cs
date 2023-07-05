using Microsoft.AspNetCore.Mvc;
using SurveyApp.Models;
using System.Diagnostics;
using AutoMapper;
using NLayer.Core.DTOs.RequestDTOs;
using NLayer.Core.DTOs.ResponseDTOs;
using NLayer.Core.Services;

namespace SurveyApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ISurveyService _surveyService;
		private readonly IMapper _mapper;

		public HomeController(ILogger<HomeController> logger, ISurveyService surveyService, IMapper mapper)
		{
			_logger = logger;
			_surveyService = surveyService;
			_mapper = mapper;
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