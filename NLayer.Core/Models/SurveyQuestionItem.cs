using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
	public class SurveyQuestionItem : BaseEntity
	{
		public int? RadioButtonSurveyQuestionId { get; set; }
		public int? CheckBoxSurveyQuestionId { get; set; }
		public string Item { get; set; }
		public int TotalSelected { get; set; } = 0;
	}
}
