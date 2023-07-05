using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace SurveyApp.Controllers
{
	public class StatisticsController : Controller
	{
		private readonly ILogger<StatisticsController> _logger;
		private readonly ISurveyService _surveyService;
		private readonly IMapper _mapper;
		private readonly IService<User> _userService;

		public StatisticsController(ILogger<StatisticsController> logger, ISurveyService surveyService, IMapper mapper, IService<User> userService)
		{
			_logger = logger;
			_surveyService = surveyService;
			_mapper = mapper;
			_userService = userService;
		}

		public async Task<IActionResult> UserSurveys(int userId)
		{
			var surveyDisplays = await _surveyService.GetSurveysOfUser(userId);
			var user = await _userService.GetByIdAsync(userId);


			ViewBag.UserId = userId;
			ViewBag.Username = user.Username;


			return View(surveyDisplays);
		}

		public async Task<IActionResult> SurveyStatistics(int surveyId, int userId)
		{
			var surveyDisplay = await _surveyService.GetSurveyDisplayInformation(surveyId);
			ViewBag.UserId = userId;
			
			return View(surveyDisplay);
		}
	}
}
