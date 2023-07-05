using NLayer.Core.Repositories;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.DTOs.RequestDTOs;
using NLayer.Core.DTOs.ResponseDTOs;
using NLayer.Core.Models;



namespace NLayer.Repository.Repositories
{
	public class SurveyRepository : GenericRepository<Survey>, ISurveyRepository
	{
		public SurveyRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<Survey> GetSurveyDisplayInformation(int surveyId)
		{
			var survey = await GetSurvey(surveyId);
			return survey;

		}

		public async Task FillSurvey(FilledSurvey filledSurvey)
		{
			var survey = await GetSurvey(filledSurvey.SurveyId);
			filledSurvey.FilledRatings.ForEach(fr => survey.RatingSurveyQuestions.Find(r => r.Id == fr.RatingQuestionId).TotalRating += fr.Rating);
			filledSurvey.FilledRadios.ForEach(fr => survey.RadioButtonSurveyQuestions.ForEach(rbsq => rbsq.SurveyQuestionItems.Find(q => q.Id == fr.SelectedOptionId).TotalSelected++));
			filledSurvey.FilledCheckBoxes.ForEach(fr => fr.SelectedOptionId.ForEach(so => survey.CheckBoxSurveyQuestions.ForEach(cbsq => cbsq.SurveyQuestionItems.Find(q => q.Id == so).TotalSelected++)));
			filledSurvey.FilledTextAreas.ForEach(fta => survey.TextAreaSurveyQuestions.Find(q => q.Id == fta.TextAreaId).OpenEndedQuestionAnswers.Add(new OpenEndedQuestionAnswer()
			{
				Answer = fta.Answer,
				TextAreaSurveyQuestionId = fta.TextAreaId
			}));
			filledSurvey.FilledTextBoxes.ForEach(ftb => survey.TextBoxSurveyQuestions.Find(q => q.Id == ftb.TextBoxId).OpenEndedQuestionAnswers.Add(new OpenEndedQuestionAnswer()
			{
				Answer = ftb.Answer,
				TextBoxSurveyQuestionId = ftb.TextBoxId
			}));
			survey.TotalParticipation++;
			await _context.SaveChangesAsync();

		}

		public async Task<List<Survey>> GetSurveysOfUser(int userId)
		{
			List<Survey> selectedSurveys = new();
			var surveys = await _context.Surveys.Where(s => s.UserId == userId).ToListAsync();
			foreach (var survey in surveys)
			{
				var selectedSurvey = await GetSurvey(survey.Id);
				selectedSurveys.Add(selectedSurvey); 

			}

			return selectedSurveys;

		}

		private async Task<Survey> GetSurvey(int surveyId)
		{
			var survey = await _context.Surveys.Include(s => s.RatingSurveyQuestions)
				.Include(s => s.CheckBoxSurveyQuestions)
				.ThenInclude(c => c.SurveyQuestionItems)
				.Include(s => s.RadioButtonSurveyQuestions)
				.ThenInclude(r => r.SurveyQuestionItems)
				.Include(s => s.TextAreaSurveyQuestions)
				.ThenInclude(ta => ta.OpenEndedQuestionAnswers)
				.Include(s => s.TextBoxSurveyQuestions)
				.ThenInclude(ta => ta.OpenEndedQuestionAnswers)
				.Where(s => s.Id == surveyId).SingleOrDefaultAsync();

			survey?.RatingSurveyQuestions.OrderBy(r => r.Id);
			survey?.CheckBoxSurveyQuestions.OrderBy(c => c.Id);
			survey?.RadioButtonSurveyQuestions.OrderBy(r => r.Id);
			survey?.TextAreaSurveyQuestions.OrderBy(ta => ta.Id);
			survey?.TextBoxSurveyQuestions.OrderBy(tb => tb.Id);


			return survey;
		} 
	}
}
