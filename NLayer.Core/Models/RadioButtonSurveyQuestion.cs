using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
	public class RadioButtonSurveyQuestion : BaseEntity
	{
		public string? Question { get; set; }
		public List<SurveyQuestionItem>? SurveyQuestionItems { get; set; }
	}
}
