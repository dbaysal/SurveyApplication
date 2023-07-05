﻿using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs.ResponseDTOs
{
	public class SurveyStatisticsDisplay
	{
		public string SurveyName { get; set; }
		public int TotalParticipation { get; set; }
		public List<RatingSurveyQuestion>? RatingSurveyQuestions { get; set; }
		public List<SurveyQuestionItem>? SurveyQuestionItems { get; set; }
	}
}
