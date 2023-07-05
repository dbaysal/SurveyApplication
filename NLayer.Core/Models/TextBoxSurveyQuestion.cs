﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
	public class TextBoxSurveyQuestion : BaseEntity
	{
		public List<OpenEndedQuestionAnswer>? OpenEndedQuestionAnswers { get; set; }
		public string Question { get; set; }
	}
}
