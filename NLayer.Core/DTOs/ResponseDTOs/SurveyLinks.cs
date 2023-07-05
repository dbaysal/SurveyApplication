using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs.ResponseDTOs
{
	public class SurveyLinks
	{
		public string StatisticsLink { get; set; }
		public string SurveyLink { get; set; }

		public SurveyLinks(int userId, int surveyId)
		{
			StatisticsLink = "https://localhost:7070/Statistics/UserSurveys?userId=" + userId;
			SurveyLink = "https://localhost:7070/Survey/FillSurvey?surveyId=" + surveyId;
		}
	}
}
