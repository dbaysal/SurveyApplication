using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
	public class OpenEndedQuestionAnswer : BaseEntity
	{
		public int? TextAreaSurveyQuestionId { get; set; }
		public int? TextBoxSurveyQuestionId { get; set; }
		public string Answer { get; set; }
	}
}
