using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Service.Services;
using System.Data;
using NLayer.Core.DTOs.RequestDTOs;
using Autofac.Core;
using NLayer.Core.DTOs.ResponseDTOs;

namespace NLayer.API.Controllers
{
	//Role Ids
	//1:default
	//2:admin

	[Route("api/[controller]")]
	[ApiController]
	public class SurveyController : CustomBaseController
	{
		private readonly ISurveyService _surveyService;
		private readonly IMapper _mapper;

		public SurveyController(ISurveyService surveyService, IMapper mapper)
		{
			_surveyService = surveyService;
			_mapper = mapper;
		}

		//Create new survey
		[HttpPost]
		[Authorize(Roles = "2")] 
		public async Task<IActionResult> Save(CreateNewSurvey createNewSurvey)
		{
			var survey = await _surveyService.AddAsync(_mapper.Map<Survey>(createNewSurvey));
			SurveyLinks surveyLinks = new(createNewSurvey.UserId, survey.Id);
			return Ok(surveyLinks);
		}


		//Get survey by id
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var surveyDisplay = await _surveyService.GetSurveyDisplayInformation(id);
			
			return Ok(surveyDisplay);
		}

		//Fill Survey
		[HttpPost("[action]")]
		public async Task<IActionResult> FillSurvey(FilledSurvey filledSurvey)
		{
			await _surveyService.FillSurvey(filledSurvey);
			return Ok();
		}


	}
}
