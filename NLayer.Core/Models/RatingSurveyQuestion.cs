using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
	public class RatingSurveyQuestion : BaseEntity
	{
		public string? Question { get; set; }
		public int TotalRating { get; set; } = 0;
	}
}
