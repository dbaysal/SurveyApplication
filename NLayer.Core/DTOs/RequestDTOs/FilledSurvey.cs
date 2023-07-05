using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs.RequestDTOs
{
	public class FilledSurvey
	{
		public int SurveyId { get; set; }
		public List<FilledRating>? FilledRatings { get; set; }
		public List<FilledCheckBox>? FilledCheckBoxes { get; set; }
		public List<FilledRadio>? FilledRadios { get; set; }
		public List<FilledTextArea>? FilledTextAreas { get; set; }
		public List<FilledTextBox>? FilledTextBoxes { get; set; }
	}
}
