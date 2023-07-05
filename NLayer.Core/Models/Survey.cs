using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
	public  class Survey : BaseEntity
	{
		public string SurveyName { get; set; }
		public int UserId { get; set; }
		public User User { get; set; }
		public int TotalParticipation { get; set; } = 0;

		public List<RatingSurveyQuestion>? RatingSurveyQuestions { get; set; }
		public List<CheckBoxSurveyQuestion>? CheckBoxSurveyQuestions { get; set; }
		public List<RadioButtonSurveyQuestion>? RadioButtonSurveyQuestions { get; set; }

		public List<TextAreaSurveyQuestion>? TextAreaSurveyQuestions { get; set; }
		public List<TextBoxSurveyQuestion>? TextBoxSurveyQuestions { get; set; }

	}
}
