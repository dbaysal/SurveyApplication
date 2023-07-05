using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs.RequestDTOs
{
	public class CreateNewSurvey
	{
		public string SurveyName { get; set; }
		public int UserId { get; set; }
		public List<RatingSurveyQuestion>? RatingSurveyQuestions { get; set; }
		public List<CheckBoxSurveyQuestion>? CheckBoxSurveyQuestions { get; set; }
		public List<RadioButtonSurveyQuestion>? RadioButtonSurveyQuestions { get; set; }
		public List<TextAreaSurveyQuestion>? TextAreaSurveyQuestions { get; set; }
		public List<TextBoxSurveyQuestion>? TextBoxSurveyQuestions { get; set; }
	}
}
