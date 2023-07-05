using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;

namespace SurveyApp.Controllers
{
	public class SurveyController : Controller
	{
		private readonly ILogger<SurveyController> _logger;
		private readonly ISurveyService _surveyService;
		private readonly IMapper _mapper;

		public SurveyController(ILogger<SurveyController> logger, ISurveyService surveyService, IMapper mapper)
		{
			_logger = logger;
			_surveyService = surveyService;
			_mapper = mapper;
		}

		public async Task<IActionResult> FillSurvey(int surveyId)
		{
			var survey = await _surveyService.GetSurveyDisplayInformation(surveyId);
			return View(survey);
		}
	}
}
