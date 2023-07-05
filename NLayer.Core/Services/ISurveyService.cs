using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Core.DTOs.RequestDTOs;
using NLayer.Core.DTOs.ResponseDTOs;
using NLayer.Core.Models;

namespace NLayer.Core.Services
{
	public interface ISurveyService : IService<Survey>
	{
		Task<SurveyDisplay> GetSurveyDisplayInformation(int surveyId);
		Task FillSurvey(FilledSurvey filledSurvey);
		Task<List<SurveyDisplay>> GetSurveysOfUser(int userId);

	}
}
