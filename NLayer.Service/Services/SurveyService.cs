using NLayer.Core.Services;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.UnitOfWorks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs.RequestDTOs;
using NLayer.Core.DTOs.ResponseDTOs;

namespace NLayer.Service.Services
{
	public class SurveyService : Service<Survey>, ISurveyService
	{
		private readonly ISurveyRepository _surveyRepository;
		private readonly IMapper _mapper;
		public SurveyService(IGenericRepository<Survey> repository, IUnitOfWork unitOfWork, ISurveyRepository survetRepository, IMapper mapper) : base(repository, unitOfWork)
		{
			_surveyRepository = survetRepository;
			_mapper = mapper;
		}

		public async Task<SurveyDisplay> GetSurveyDisplayInformation(int surveyId)
		{
			var survey = await _surveyRepository.GetSurveyDisplayInformation(surveyId);
			return _mapper.Map<SurveyDisplay>(survey);
		}

		public async Task FillSurvey(FilledSurvey filledSurvey)
		{
			await _surveyRepository.FillSurvey(filledSurvey);
		}

		public async Task<List<SurveyDisplay>> GetSurveysOfUser(int userId)
		{
			var surveys = await _surveyRepository.GetSurveysOfUser(userId);
			var surveyDisplays = _mapper.Map<List<SurveyDisplay>>(surveys);

			return surveyDisplays;

		}
	}
}
