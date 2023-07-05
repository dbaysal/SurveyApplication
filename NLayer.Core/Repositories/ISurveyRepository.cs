using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Core.DTOs.RequestDTOs;
using NLayer.Core.DTOs.ResponseDTOs;
using NLayer.Core.Models;

namespace NLayer.Core.Repositories
{
	public interface ISurveyRepository : IGenericRepository<Survey>
	{
		Task<Survey> GetSurveyDisplayInformation(int surveyId);
		Task FillSurvey(FilledSurvey filledSurvey);
		Task<List<Survey>> GetSurveysOfUser(int userId);
	}
}
