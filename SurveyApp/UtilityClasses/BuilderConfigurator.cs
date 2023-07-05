using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Repository;
using NLayer.Repository.Repositories;
using NLayer.Service.Services;

namespace SteamReplica.UtilityClasses
{
	public class BuilderConfigurator
	{
		public static void AddScopes(WebApplicationBuilder builder)
		{
			
			
			
			builder.Services.AddScoped<ISurveyRepository, SurveyRepository>();
			builder.Services.AddScoped<ISurveyService, SurveyService>();
	

		}

		public static void SqlConnection(WebApplicationBuilder builder, string connectionString)
		{
			builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));
		}

		public static void AddAuthentication(WebApplicationBuilder builder)
		{
			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(option =>
				{
					option.LoginPath = "/User/Login";
					option.ReturnUrlParameter = "returnURL";

				});
		}
	}
}
