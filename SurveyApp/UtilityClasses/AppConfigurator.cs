namespace SteamReplica.UtilityClasses
{
	public class AppConfigurator
	{
		public static void UseMvc(WebApplication app)
		{
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Game}/{action=Index}");
			});
		}

		public static void HttpRequestPipeline(WebApplication app)
		{
			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
		}


	}
}
